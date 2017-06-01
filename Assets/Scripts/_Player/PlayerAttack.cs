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
        else if (other.gameObject.tag == "StarEnemy") {
            //Debug.Log ("Enter star Enemy");
            starEnemyHealth = other.gameObject.GetComponent<StarEnemyHealth>();
            starEnemyInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            enemyInRange = false;
            enemyHealth = null;
        }
        else if (other.gameObject.tag == "StarEnemy") {
            starEnemyInRange = false;
            enemyHealth = null;
        }
    }


    private void Update() {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && enemyInRange) {
            Attack();
        }
        if (timer >= timeBetweenAttacks && starEnemyInRange) {
            attackStar();
        }
    }

    void Attack() {
        timer = 0f;

        if (enemyHealth.currentHealth > 0) {
            enemyHealth.TakeDamage(attackDamage);
        }
    }

    void attackStar(){
        timer = 0f;

        if (starEnemyHealth.currentHealth > 0) {
            starEnemyHealth.TakeDamage(attackDamage);
        }
    }


}
