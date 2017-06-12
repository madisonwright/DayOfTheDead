using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuOptions : MonoBehaviour {

    public void Revive() {
        SpiritEnergyManager.Instance.Energy = 0;
        LevelManager.Instance.LoadLevel(1);
    }

    public void Quit() {
        SpiritEnergyManager.Instance.Energy = 0;
        SceneManager.LoadScene("Bootstrap");
    }
}
