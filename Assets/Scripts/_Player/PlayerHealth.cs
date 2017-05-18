﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	//public Slider healthSlider;
	public Image damageImage;
	public AudioSource source;
	public AudioSource source2;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public Text health;


	//Animator anim;
	PlayerMovementController playerMovement;
	//PlayerShooting playerShooting;
	bool isDead;
	//bool damaged;

	void Start(){
		health.text = "Health: 100";
	}

	void Awake ()
	{
		//anim = GetComponent <Animator> ();
		//playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <PlayerMovementController> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
	}


	void Update ()
	{
		/*
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		damaged = false;
		*/
	}


	public void TakeDamage (int amount)
	{
		//damaged = true;

		currentHealth -= amount;
		health.text = "Health: " + currentHealth.ToString();

		//healthSlider.value = currentHealth;

		source.Play ();

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;

		//playerShooting.DisableEffects ();

		//anim.SetTrigger ("Die");

		source2.Play ();

		playerMovement.enabled = false;
		//playerShooting.enabled = false;
	}


	public void RestartLevel ()
	{
		SceneManager.LoadScene (0);
	}
}