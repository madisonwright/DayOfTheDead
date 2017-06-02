using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 20;

    EnemyHealth enemyHealth;
    StarEnemyHealth starEnemyHealth;
    bool enemyInRange;
    bool starEnemyInRange;
    float timer;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            //Debug.Log ("Enter Enemy");
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
