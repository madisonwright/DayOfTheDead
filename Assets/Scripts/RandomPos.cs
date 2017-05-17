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
	     x = Random.Range(-2, 2);
	     z = Random.Range(-2, 2);
	     pos = new Vector3(transform.position.x + x, transform.position.y-2, transform.position.z + z);
	     transform.position = pos;
	 }
}
