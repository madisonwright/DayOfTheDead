using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vanish : MonoBehaviour {

	public Text start;

	void Update () {
		if(Input.GetMouseButton(0)) {
	        start.text = "";
	    }
	}
}
