using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratest : MonoBehaviour {

	public Transform player;

    private Vector3 offset;

    private void Start() {
        offset = transform.position - player.position;
    }

    private void LateUpdate() {
    	Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, player.rotation, 100.0f*Time.deltaTime);
    	transform.rotation = Quaternion.Euler(25,newRotation.y/2,0);
    	//..var newRotation = player.transform.eulerAngles.y;
    	//var finalRotation = Mathf.Clamp(newRotation,-90.0f,90.0f);
    	//..transform.rotation = Quaternion.Euler(25,newRotation,0);

        //var newPosition = player.position + offset;
        //newPosition.x = Mathf.Clamp (newPosition.x, 25.0f, 175.0f);
        //transform.position = newPosition;
        //Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, player.rotation, 10.0f*Time.deltaTime);



    }
}
