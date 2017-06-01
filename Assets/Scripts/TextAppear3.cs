using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear3 : MonoBehaviour {

	private AudioSource source;
	private int step;
	public Image text1;
	public Image text2;
	public Image text3;

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
			} else if (step == 2){
				text1.gameObject.SetActive(false);
				text2.gameObject.SetActive(true);
				step += 1;
			} else if (step == 3){
				text2.gameObject.SetActive(false);
				step = 1;
			}
		}
	}
}
