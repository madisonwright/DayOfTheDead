using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randome_spawn2 : MonoBehaviour {

	private float x;
	private float y;
	private float z;

	private Vector3 pos;

    private float area;
    private float areaMaxX;
    private float areaMinX;
    private float areaMinZ;
    private float areaMaxZ;


    void humanArea1spawnArea(){
        areaMaxX = 76;
        areaMinX = 37;
        areaMinZ = 471;
        areaMaxZ = 521;
    }
    void humanArea1spawnArea2(){
        areaMinX = 122;
        areaMaxX = 158;
        areaMinZ = 470;
        areaMaxZ = 534;
    }
    void humanArea1spawnArea3(){
        areaMinX = 80;
        areaMaxX = 120;
        areaMinZ = 409;
        areaMaxZ = 442;
    }

    void Start()
    {
        GetRandomLocation ();
    }

    void GetRandomLocation(){
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

        transform.position = pos;
    }
}
