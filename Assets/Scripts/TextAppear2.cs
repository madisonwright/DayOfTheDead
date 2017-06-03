﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear2 : MonoBehaviour {

	private AudioSource source;
	private int step;
	public Image text1;
	private bool speak;
	public GameObject skull;

	void Start()
	{
		step = 1;
		source = GetComponent<AudioSource>();
		speak = false;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("TextDetector")) 
		{
			speak = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.CompareTag("TextDetector"))
		{
			speak = false;
			skull.GetComponent<TextAppear2>().text1.gameObject.SetActive(false);
			step = 1;

		}
	}

	void Update(){
		if (speak == true){
<<<<<<< HEAD
			if(Input.GetMouseButtonDown(0)) {
=======
			if(Input.GetKeyUp(KeyCode.F)) {
>>>>>>> refs/remotes/origin/master
	        	source.Play();

				if (step == 1){
					skull.GetComponent<TextAppear2>().text1.gameObject.SetActive(true);
					step += 1;
				} else if (step == 2){
					skull.GetComponent<TextAppear2>().text1.gameObject.SetActive(false);
					step = 1;
				}
	    	}
	    }
	}
}

