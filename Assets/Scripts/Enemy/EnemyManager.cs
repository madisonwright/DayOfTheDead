using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	//public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	private int num_enemy = 0;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{
		//if(playerHealth.currentHealth <= 0f)
		//{
		//	return;
		//}
		if (num_enemy >= 2){
			return;
		}
		num_enemy += 1;
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}