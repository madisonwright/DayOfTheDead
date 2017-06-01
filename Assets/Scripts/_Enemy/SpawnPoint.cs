using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    public GameObject enemy;
    public GameObject star;
    private float spawnTime = 0.1f;
    public Transform[] spawnPoints;
    private int delay = 0;

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
        if (num_enemy >= 3){
            return;
        }
        num_enemy += 1;
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        float random = Random.Range (0.0f, 5.0f);

        Vector3 spawn1 = new Vector3 (gameObject.transform.position.x + 10, 1, gameObject.transform.position.z + 10); 
        Vector3 spawn2 = new Vector3 (gameObject.transform.position.x - 10, 1, gameObject.transform.position.z - 10); 
        Vector3 spawn3 = new Vector3 (gameObject.transform.position.x - 10, 1, gameObject.transform.position.z + 10); 
        if (delay == 0){
            if (random > 4.0) {
                Instantiate (enemy, spawn1, spawnPoints [spawnPointIndex].rotation);
                Instantiate (enemy, spawn2, spawnPoints [spawnPointIndex].rotation);
                Instantiate (enemy, spawn3, spawnPoints [spawnPointIndex].rotation);
                StartCoroutine (_Delay ());
            } else if (random > 3.0) {
                Instantiate (star, spawn1, spawnPoints [spawnPointIndex].rotation);
                Instantiate (enemy, spawn2, spawnPoints [spawnPointIndex].rotation);
                Instantiate (enemy, spawn3, spawnPoints [spawnPointIndex].rotation);
                StartCoroutine (_Delay ());
            } else if (random > 2.0) {
                Instantiate (enemy, spawn1, spawnPoints [spawnPointIndex].rotation);
                Instantiate (star, spawn2, spawnPoints [spawnPointIndex].rotation);
                Instantiate (enemy, spawn3, spawnPoints [spawnPointIndex].rotation);
                StartCoroutine (_Delay ());
            } else if (random > 1.0) {
                Instantiate (enemy, spawn1, spawnPoints [spawnPointIndex].rotation);
                Instantiate (enemy, spawn2, spawnPoints [spawnPointIndex].rotation);
                Instantiate (star, spawn3, spawnPoints [spawnPointIndex].rotation);
                StartCoroutine (_Delay ());
            } else if (random > 0.0) {
                Instantiate (enemy, spawn1, spawnPoints [spawnPointIndex].rotation);
                Instantiate (star, spawn2, spawnPoints [spawnPointIndex].rotation);
                Instantiate (star, spawn3, spawnPoints [spawnPointIndex].rotation);
                StartCoroutine (_Delay ());
            } else {
                Instantiate (star, spawn1, spawnPoints [spawnPointIndex].rotation);
                Instantiate (star, spawn2, spawnPoints [spawnPointIndex].rotation);
                Instantiate (star, spawn3, spawnPoints [spawnPointIndex].rotation);
                StartCoroutine (_Delay ());
            }
        }
    }

    private IEnumerator _Delay() {
            delay = 1;
            yield return new WaitForSeconds(45f);
            delay = 0;    
    }
}
