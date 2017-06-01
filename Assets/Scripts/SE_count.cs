﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE_count : MonoBehaviour {
	public int count2 = 0;
    public Slider spirit_energy;
    public Text collection_energy;
    private AudioSource source;
    public GameObject particles;
    ParticleSystem hitParticles;

    void Start(){
    	source = GetComponent<AudioSource>();
    	collection_energy.text = "Chillis: 0";
    }

    private void OnEnable() {
        EventMessenger.StartListening(Events.WORLD_SWITCH_STARTED, OnWorldSwitchStarted);
    }

    void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("SpiritEnergy")) 
		{
			source.Play();
			particles.SetActive(true);
            StartCoroutine(_UpdateSlider());
			StartCoroutine(_Hide());
		}else if (other.gameObject.CompareTag ("Collection")){
			source.Play();
			count2 += 1;
			collection_energy.text = "Chillis: " + count2.ToString();
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
            yield return new WaitForSeconds(1.5f);
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
