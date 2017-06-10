using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratest : MonoBehaviour {

	public Transform player;
	public float x_angle;
	public float y_min;
	public float y_max;

    private Vector3 offset;

    private void Start() {

        offset = transform.position - player.position;
    }

    private void LateUpdate() {
    	//var newRotation = player.transform.eulerAngles.y;
    	//Mathf.Clamp(newRotation,-90.0f,90.0f);
    	//transform.rotation = Quaternion.Euler(35,newRotation,0);

        //var newPosition = player.position + offset;
        //newPosition.x = Mathf.Clamp (newPosition.x, 25.0f, 175.0f);
        //transform.position = newPosition;
        //Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, player.rotation, 10.0f*Time.deltaTime);

 			//new line to slowly turn towards the mouse
            //Quaternion pla = Quaternion.LookRotation(playerToMouse);
            //Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, pla, turn_speed*Time.deltaTime );
            //transform.rotation = newRotation;
    	var newPosition = player.position + offset;
        newPosition.x = Mathf.Clamp (newPosition.x, 25.0f, 175.0f);
        transform.position = newPosition;

    	int floorMask = LayerMask.GetMask("Floor");
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit;
		if (Physics.Raycast(camRay, out mouseHit, 100.0f, floorMask)) {
            Vector3 playerToMouse = mouseHit.point - player.transform.position;
            playerToMouse.y = 0f;
            Quaternion pla = Quaternion.LookRotation(playerToMouse);
            
            if (pla.y <= y_min || pla.y >= y_max){
	            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, pla, 20*Time.deltaTime );
	            newRotation.x = Mathf.Clamp(newRotation.x,x_angle,x_angle);
	            transform.rotation = newRotation;
        	}
        }
    	
            


    }
}
