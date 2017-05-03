using UnityEngine;

public enum WorldType {
    Human,
    Spirt
}

public class WorldController : MonoBehaviour {
    public WorldType worldType;

    public void Deactivate() {
        this.gameObject.SetActive(false);
    }

    public void Activate() {
        this.gameObject.SetActive(true);
    }
}
