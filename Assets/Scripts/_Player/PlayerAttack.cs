using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 20;

    EnemyHealth enemyHealth;
    bool enemyInRange;
    float timer;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            enemyInRange = false;
            enemyHealth = null;
        }
    }


    private void Update() {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && enemyInRange) {
            Attack();
        }
    }

    void Attack() {
        timer = 0f;

        if (enemyHealth.currentHealth > 0) {
            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
