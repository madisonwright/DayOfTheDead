using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour {

	 private float x;
	 private float y;
	 private float z;
	 private Vector3 pos;
	 
	 void Start()
	 {
	     x = Random.Range(-45, 45);
	     y = 1;
	     z = Random.Range(-45, 45);
	     pos = new Vector3(x, y, z);
	     transform.position = pos;
	 }
}
