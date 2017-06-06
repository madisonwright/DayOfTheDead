using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEnd : MonoBehaviour {

	public Text move_on; 

	void Start(){
		move_on.text = "";
	}

	private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            move_on.text = "Press the Spacebar to travel to the Human world";
        }
    }
}

