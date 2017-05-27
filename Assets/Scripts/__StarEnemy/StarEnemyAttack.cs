using UnityEngine;

public class StarEnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    //public bool attacking = false;

    //Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    StarEnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<StarEnemyHealth>();
        //anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("PlayerEnemyDetector"))
        {
            playerInRange = true;
            //attacking = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject.CompareTag("PlayerEnemyDetector"))
        {
            playerInRange = false;
            //attacking = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }
        /*
        if(playerHealth.currentHealth <= 0)
        {
            //anim.SetTrigger ("PlayerDead");
            return;
        }
        */      
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}