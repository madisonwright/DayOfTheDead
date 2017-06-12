using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : PersistentSingleton<LevelManager> {
    public LevelInfo[] levels;
    public WorldType currentWorld;

    private LevelInfo currentLevel;
    private Dictionary<WorldType, WorldController> currentWorlds = new Dictionary<WorldType, WorldController>();


    protected override void Awake() {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public bool IsLoading {
        get; private set;
    }

	public bool IsTutorial {
		get { 
			return SceneManager.GetActiveScene ().name.ToLower ().Contains ("tutorial");
		}
	}

    public void LoadLevel(int number) {
        if(levels.Any(l => l.Number == number)) {
            currentLevel = levels.First(l => l.Number == number);
            IsLoading = true;
            EventMessenger.TriggerEvent<LevelInfo>(Events.LEVEL_LOADING, currentLevel);
            SceneManager.LoadScene(currentLevel.HumanWorldSceneName);
            SceneManager.LoadScene(currentLevel.SpiritWorldSceneName, LoadSceneMode.Additive);
        } else {
            Debug.Log(string.Format("Level {0} does not exist.", number));
        }
    }

    public void SwitchWorld() {
        currentWorlds[currentWorld].Deactivate();
        currentWorld = currentWorld == WorldType.Human ? WorldType.Spirt : WorldType.Human;
        currentWorlds[currentWorld].Activate();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode) {
        var environments = GameObject.FindObjectsOfType<WorldController>();
        if(environments.Length == 2) {
            currentWorlds[environments[0].worldType] = environments[0];
            currentWorlds[environments[1].worldType] = environments[1];
            currentWorld = WorldType.Human;
            currentWorlds[WorldType.Spirt].Deactivate();
            IsLoading = false;
            EventMessenger.TriggerEvent<LevelInfo>(Events.LEVEL_LOADED, currentLevel);
        }
    }
}
