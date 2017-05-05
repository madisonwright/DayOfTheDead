using UnityEngine;

public class MacheteHitDetector : MonoBehaviour {
    public int damageAmount = 0;
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageAmount);
        }
    }
}
