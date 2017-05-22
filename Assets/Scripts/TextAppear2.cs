using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear2 : MonoBehaviour {

	private AudioSource source;
	private int step;
	public Image text1;


	void Start()
	{
		step = 1;
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PlayerPickupDetector")) 
		{
			source.Play();
			if (step == 1){
				text1.gameObject.SetActive(true);
				step += 1;
			} else{
				text1.gameObject.SetActive(false);
				step = 1;
			}
		}
	}
}
