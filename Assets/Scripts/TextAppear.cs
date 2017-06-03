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
			skull.GetComponent<TextAppear>().text1.gameObject.SetActive(false);
			skull.GetComponent<TextAppear>().text2.gameObject.SetActive(false);
			skull.GetComponent<TextAppear>().text3.gameObject.SetActive(false);
			skull.GetComponent<TextAppear>().text4.gameObject.SetActive(false);
			skull.GetComponent<TextAppear>().text5.gameObject.SetActive(false);
			skull.GetComponent<TextAppear>().text6.gameObject.SetActive(false);
			step = 1;

		}
	}

	void Update(){
		if (speak == true){
			if(Input.GetMouseButtonDown(0)) {
	        	source.Play();
				if (step == 1){
					skull.GetComponent<TextAppear>().text1.gameObject.SetActive(true);
					step += 1;
				} else if (step == 2){
					skull.GetComponent<TextAppear>().text1.gameObject.SetActive(false);
					skull.GetComponent<TextAppear>().text2.gameObject.SetActive(true);
					step += 1;
				} else if (step == 3){
					skull.GetComponent<TextAppear>().text2.gameObject.SetActive(false);
					skull.GetComponent<TextAppear>().text3.gameObject.SetActive(true);
					step += 1;				
				} else if (step == 4){
					skull.GetComponent<TextAppear>().text3.gameObject.SetActive(false);
					skull.GetComponent<TextAppear>().text4.gameObject.SetActive(true);
					step += 1;
				} else if (step == 5){
					skull.GetComponent<TextAppear>().text4.gameObject.SetActive(false);
					skull.GetComponent<TextAppear>().text5.gameObject.SetActive(true);
					step += 1;
				} else if (step == 6){
					skull.GetComponent<TextAppear>().text5.gameObject.SetActive(false);
					skull.GetComponent<TextAppear>().text6.gameObject.SetActive(true);
					step += 1;
				} else if (step == 7){
					skull.GetComponent<TextAppear>().text6.gameObject.SetActive(false);
					step = 1;
				}
	    	}
	    }
	}
}