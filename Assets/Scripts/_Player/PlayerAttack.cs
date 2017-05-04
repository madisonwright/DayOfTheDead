using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 20;


	//Animator anim;
	GameObject enemy;
	//PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool enemyInRange;
	float timer;


	void Awake ()
	{
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		//playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = enemy.GetComponent<EnemyHealth>();
		//anim = GetComponent <Animator> ();
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			enemyInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			enemyInRange = false;
		}
	}


	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && enemyInRange/* && enemyHealth.currentHealth > 0*/)
		{
			Attack ();
		}
			
	}


	void Attack ()
	{
		timer = 0f;

		if(enemyHealth.currentHealth > 0)
		{
			enemyHealth.TakeDamage (attackDamage);
		}
	}
}
