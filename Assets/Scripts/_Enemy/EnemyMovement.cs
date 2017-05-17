using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyMovement : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    float ran_x;
    float ran_z;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        ran_x = Random.Range (-5.0f, 5.0f);
        ran_z = Random.Range (-5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update () {
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0) {
            if ((gameObject.transform.position - player.position).sqrMagnitude <= 100) {
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
