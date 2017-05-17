using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public AudioClip deathClip;

    GameObject player;
	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
    BoxCollider capsuleCollider;
	bool isDead;
	bool isSinking;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		//hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <BoxCollider> ();
        player = GameObject.FindGameObjectWithTag ("Player");
		currentHealth = startingHealth;
	}


	void Update ()
	{
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}


	public void TakeDamage (int amount) //, Vector3 hitPoint)
	{
		if(isDead)
			return;

		enemyAudio.Play ();

		currentHealth -= amount;
        gameObject.transform.LookAt (player.transform.position);
        gameObject.transform.position += (gameObject.transform.position - player.transform.position) / 8.0F;

		//hitParticles.transform.position = hitPoint;
		//hitParticles.Play();

		if(currentHealth <= 0)
		{
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;

        anim.enabled = false;

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
		StartSinking ();
	}


	public void StartSinking ()
	{
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		Destroy (gameObject, 2f);
	}
}
