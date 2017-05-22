using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour {

	private AudioSource source;
	private int step;
	public Image text1;
	public Image text2;
	public Image text3;
	public Image text4;
	public Image text5;
	public Image text6;


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
				text3.gameObject.SetActive(true);
				step += 1;				
			} else if (step == 4){
				text3.gameObject.SetActive(false);
				text4.gameObject.SetActive(true);
				step += 1;
			} else if (step == 5){
				text4.gameObject.SetActive(false);
				text5.gameObject.SetActive(true);
				step += 1;
			} else if (step == 6){
				text5.gameObject.SetActive(false);
				text6.gameObject.SetActive(true);
				step += 1;
			} else if (step == 7){
				text6.gameObject.SetActive(false);
				step = 1;
			}
		}
	}
}
