using System.Collections;

using UnityEngine;

public class NextScene : MonoBehaviour {
    private IEnumerator Start() {
        yield return null;
        LevelManager.Instance.LoadLevel(1);
    }
}
