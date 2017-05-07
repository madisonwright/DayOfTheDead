using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    public GameObject enemy;
    private float spawnTime = 0.1f;
    public Transform[] spawnPoints;

    private int num_enemy;
    private float timer;

    void Start ()
    {
        timer = 5;
        num_enemy = 0;
    }

    void Update(){
        timer = timer + Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "PlayerEnemyDetector") {
            if (timer >= 5.0) {
                print (timer);
                num_enemy = 0;
                InvokeRepeating ("Spawn", spawnTime, spawnTime);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "PlayerEnemyDetector") {
            timer = 0;

        }
    }


    void Spawn ()
    {
        //if(playerHealth.currentHealth <= 0f)
        //{
        //  return;
        //}
        print(num_enemy);
        if (num_enemy >= 4){
            return;
        }
        num_enemy += 1;
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
