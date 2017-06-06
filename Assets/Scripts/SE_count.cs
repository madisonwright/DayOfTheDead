﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE_count : MonoBehaviour {
	public int count2 = 0;
    public Slider spirit_energy;
    public Text collection_energy;
    public AudioSource source;
    public GameObject particles;
    ParticleSystem hitParticles;
    private int goal = 4;

    //GameObject player;
    //PlayerHealth playerHealth;

    void Awake(){
    	collection_energy.text = "0/?";
        //player = GameObject.FindGameObjectWithTag ("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();

    }

    private void OnEnable() {
        EventMessenger.StartListening(Events.WORLD_SWITCH_STARTED, OnWorldSwitchStarted);
    }

    void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("SpiritEnergy")) 
		{
			source.Play();
            particles.SetActive (true);
            StartCoroutine (_UpdateSlider ());
            StartCoroutine (_Hide ());

		}else if (other.gameObject.CompareTag ("Collection")){
			source.Play();
			count2 += 1;
			collection_energy.text = count2.ToString() + "/" + goal.ToString();
	    	hitParticles = other.GetComponentInChildren <ParticleSystem> ();
			hitParticles.Play();
			StartCoroutine(_reward(other.gameObject));
		}
	}

	private IEnumerator _Hide() {
            yield return new WaitForSeconds(0.5f);
			particles.SetActive(false);
    }

    private IEnumerator _reward(GameObject other) {
            yield return new WaitForSeconds(.5f);
			other.SetActive(false);
    }

    private IEnumerator _UpdateSlider() {
        yield return null;
        spirit_energy.value = SpiritEnergyManager.Instance.Energy;
    }

    private void OnWorldSwitchStarted() {
        StartCoroutine(_UpdateSlider());
    }

    private void OnDisable() {
        EventMessenger.StopListening(Events.WORLD_SWITCH_STARTED, OnWorldSwitchStarted);
    }
}
