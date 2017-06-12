using UnityEngine;

public class DeathMenuOptions : MonoBehaviour {

    public void Revive() {
        LevelManager.Instance.LoadLevel(1);
        SpiritEnergyManager.Instance.Energy = 0;
    }

    public void Quit() {

    }
}
