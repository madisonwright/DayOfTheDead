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
			skull.GetComponent<TextAppear3>().text1.gameObject.SetActive(false);
			skull.GetComponent<TextAppear3>().text2.gameObject.SetActive(false);
			skull.GetComponent<TextAppear3>().text3.gameObject.SetActive(false);
			step = 1;

		}
	}

	void Update(){
		if (speak == true){
			if(Input.GetKeyDown(KeyCode.F)) {
	        	source.Play();

				if (step == 1){
					skull.GetComponent<TextAppear3>().text1.gameObject.SetActive(true);
					step += 1;
				} else if (step == 2){
					skull.GetComponent<TextAppear3>().text1.gameObject.SetActive(false);
					skull.GetComponent<TextAppear3>().text2.gameObject.SetActive(true);
					step += 1;
				} else if (step == 3){
					skull.GetComponent<TextAppear3>().text2.gameObject.SetActive(false);
					skull.GetComponent<TextAppear3>().text3.gameObject.SetActive(true);
					step += 1;
				} else if (step == 4){
					skull.GetComponent<TextAppear3>().text3.gameObject.SetActive(false);
					step = 1;
				}

	    	}
	    }
	}
}
