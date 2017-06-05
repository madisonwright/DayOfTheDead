using UnityEngine;
using UnityEngine.SceneManagement;


public class StartOptions : MonoBehaviour {
	public string sceneToStart = "";

	public Animator animColorFade;
	public AnimationClip fadeColorAnimationClip;
	
	private ShowPanels showPanels;

	void Awake() {
		showPanels = GetComponent<ShowPanels> ();
	}

    public void StartButtonClicked() {
		Invoke ("LoadDelayed", fadeColorAnimationClip.length * .5f);
		animColorFade.SetTrigger ("fade");
	}

	public void LoadDelayed() {
		showPanels.HideMenu ();
		//SceneManager.LoadScene (sceneToStart);
        LevelManager.Instance.LoadLevel(1);
	}

	public void HideDelayed() {
		showPanels.HideMenu();
	}
}
