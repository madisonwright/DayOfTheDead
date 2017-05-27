using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class StarEnemyMovement : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    StarEnemyHealth starEnemyHealth;
    NavMeshAgent nav;


    float speed = 50f;
    int time_between_attack = 3;
    float timer = 0f;
    float step;
    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        starEnemyHealth = GetComponent <StarEnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();

    }

    // Update is called once per frame
    void Update () {
        if (playerHealth.currentHealth > 0 && starEnemyHealth.currentHealth > 0) {
            if ((gameObject.transform.position - player.position).sqrMagnitude <= 900) {
                WaitState ();
                if (timer >= time_between_attack) {
                    AttackState ();
                    timer = 0;
                    time_between_attack = 5;
                }
            } else {
                timer = 0f;
                MoveState();
            }


        } else {
            nav.enabled = false;
        }

    }

    void AttackState(){
        //attack = true;
        nav.enabled = true;
        //Debug.Log ("attack");
        Vector3 now = gameObject.transform.position;
        Vector3 path = (player.position - gameObject.transform.position).normalized;
        step = speed * Time.deltaTime;


        int i = 0;

        while (i < 30){

            gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, player.position, step);

            i++;

        }

        //nav.Warp(new Vector3 (player.position.x + 1, player.position.y, player.position.z+1));
        //gameObject.transform.position = new Vector3 (player.position.x + 1, player.position.y, player.position.z+1);


        //nav.Warp(now);


    }

    void WaitState(){
        timer += Time.deltaTime;
        nav.enabled = false;
    }

    void MoveState(){
        nav.enabled = true;
        nav.SetDestination (player.position);
    }

}