using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHerbManager : MonoBehaviour {
    GameObject player;
    PlayerHealth playerHealth;
	// Use this for initialization

    private float area;
    Vector3 pos;
    float x;
    float z;

    private float areaMaxX;
    private float areaMinX;
    private float areaMinZ;
    private float areaMaxZ;

    // human area 1
    void humanArea1spawnArea(){
        areaMaxX = 84;
        areaMinX = 48;
        areaMinZ = 40;
        areaMaxZ = 67;
    }
    void humanArea1spawnArea2(){
        areaMinX = 41;
        areaMaxX = 170;
        areaMinZ = 87;
        areaMaxZ = 136;
    }
    void humanArea1spawnArea3(){
        areaMinX = 98;
        areaMaxX = 113;
        areaMinZ = 149;
        areaMaxZ = 185;
    }

    //human area 2
    void humanArea2spawnArea(){
        areaMaxX = 153;
        areaMinX = 123;
        areaMinZ = 233;
        areaMaxZ = 328;
    }
    void humanArea2spawnArea2(){
        areaMinX = 101;
        areaMaxX = 147;
        areaMinZ = 333;
        areaMaxZ = 367;
    }
    void humanArea2spawnArea3(){
        areaMinX = 6;
        areaMaxX = 25;
        areaMinZ = 229;
        areaMaxZ = 379;
    }

    // human area 3
    void humanArea3spawnArea(){
        areaMaxX = 76;
        areaMinX = 37;
        areaMinZ = 471;
        areaMaxZ = 521;
    }
    void humanArea3spawnArea2(){
        areaMinX = 122;
        areaMaxX = 158;
        areaMinZ = 470;
        areaMaxZ = 534;
    }
    void humanArea3spawnArea3(){
        areaMinX = 80;
        areaMaxX = 120;
        areaMinZ = 409;
        areaMaxZ = 442;
    }


	void Start () {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.count1 == 3) {
            randome_spawn[] herbSpawn = Resources.FindObjectsOfTypeAll<randome_spawn>();
            for (int i = 0; i < 4; i++) {
                herbSpawn [i].gameObject.SetActive (true);
                herbSpawn [i].gameObject.transform.position = GetRandomLocation ();

            }
            playerHealth.count1 = 0;
        }
        else if (playerHealth.count2 == 3) {
            randome_spawn1[] herbSpawn = Resources.FindObjectsOfTypeAll<randome_spawn1>();
            for (int i = 0; i < 3; i++) {
                herbSpawn [i].gameObject.SetActive (true);
                herbSpawn [i].gameObject.transform.position = GetRandomLocation2 ();

            }
            playerHealth.count2 = 0;
        }
        else if (playerHealth.count3 == 3) {
            randome_spawn2[] herbSpawn = Resources.FindObjectsOfTypeAll<randome_spawn2>();
            for (int i = 0; i < 3; i++) {
                herbSpawn [i].gameObject.SetActive (true);
                herbSpawn [i].gameObject.transform.position = GetRandomLocation3 ();

            }
            playerHealth.count3 = 0;
        }

	}
    Vector3 GetRandomLocation(){
        area = Random.Range (0, 3);

        if (area >= 2) {
            humanArea1spawnArea ();
        } else if (area >= 1) {
            humanArea1spawnArea2 ();
        } else {
            humanArea1spawnArea3 ();
        }
        x = Random.Range(areaMinX, areaMaxX);
        z = Random.Range(areaMinZ, areaMaxZ);
        pos = new Vector3(x, 1, z);
        return pos;
    }


    Vector3 GetRandomLocation2(){
        area = Random.Range (0, 3);

        if (area >= 2) {
            humanArea2spawnArea ();
        } else if (area >= 1) {
            humanArea2spawnArea2 ();
        } else {
            humanArea2spawnArea3 ();
        }
        x = Random.Range(areaMinX, areaMaxX);
        z = Random.Range(areaMinZ, areaMaxZ);
        pos = new Vector3(x, 1, z);
        return pos;
    }

    Vector3 GetRandomLocation3(){
        area = Random.Range (0, 3);

        if (area >= 2) {
            humanArea3spawnArea ();
        } else if (area >= 1) {
            humanArea3spawnArea2 ();
        } else {
            humanArea3spawnArea3 ();
        }
        x = Random.Range(areaMinX, areaMaxX);
        z = Random.Range(areaMinZ, areaMaxZ);
        pos = new Vector3(x, 1, z);
        return pos;
    }



}
