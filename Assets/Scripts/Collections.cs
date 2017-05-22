using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour {

	public int count;


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PlayerPickupDetector")) 
		{
			if (other.gameObject.GetComponent<SE_count>().count2 == count){
				gameObject.SetActive(false);
			}
		}
	}
	


}
