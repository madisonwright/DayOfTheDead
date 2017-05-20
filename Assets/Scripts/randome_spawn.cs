using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randome_spawn : MonoBehaviour {

	private float x;
	private float y;
	private float z;
	public float x_bound;
	public float z_boundl;
	public float z_boundu;
	private Vector3 pos;

	void Start()
	{
		x = Random.Range(0, x_bound);
		z = Random.Range(z_boundl, z_boundu);
		pos = new Vector3(x, 1, z);
		transform.position = pos;
	}
}
