using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour {

	private int count;
	private AudioSource source5;


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Colletion")) 
		{
			source5.Play();
			count += 1;
		}
	}
	


}
