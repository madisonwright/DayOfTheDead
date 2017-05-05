using UnityEngine;

public class SpiritPickupController : MonoBehaviour {
    public float amount = 0.0f;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PlayerPickupDetector")) {
            SpiritEnergyManager.Instance.Energy += amount;
            Destroy(gameObject);
        }
    }
}
