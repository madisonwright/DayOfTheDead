using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyMovement : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    public float ran_x;
    public float ran_z;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        ran_x = Random.Range (-2.0f, 2.0f);
        ran_z = Random.Range (-2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update () {
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0) {
            if ((gameObject.transform.position - player.position).sqrMagnitude <= ((ran_x * ran_x) + (ran_z * ran_z)) + 1) {
                nav.SetDestination (player.position);
            } else {
                float x = player.position.x;
                float z = player.position.z;
                Vector3 position = new Vector3(x + ran_x*2, 0, z + ran_z*2);
                nav.SetDestination (position);
            }


        } else {
            nav.enabled = false;
        }

    }
}
