using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerTutorial : MonoBehaviour {
	public Transform player;
	private Vector3 offset;

	private void Start() {
		offset = transform.position - player.position;
	}

	private void LateUpdate() {
		var newPosition = player.position + offset;
		newPosition.x = Mathf.Clamp (newPosition.x, 0.0f, 50.0f);
		transform.position = newPosition;

	}
}

