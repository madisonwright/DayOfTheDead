using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour {

	private AudioSource source;
	public Text hellotext;

	void Start()
	{
		hellotext.text = "";
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("TextDetector")) 
		{
			source.Play();
			hellotext.text = "Hello, I am a Sugar Sphere!";
			
		}
	}
}
