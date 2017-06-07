using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour {
	public float amplitude;
	public float velocity;
	public float tmp;
	public Vector3 pos;


	// Use this for initialization
	void Start () {
		//tmp = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		pos.y = amplitude * Mathf.Sin (velocity * Time.time);
		transform.position += pos;
	}
}
