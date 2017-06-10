using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randome_spawn1 : MonoBehaviour {

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
        areaMaxX = 153;
        areaMinX = 123;
        areaMinZ = 233;
        areaMaxZ = 328;
    }
    void humanArea1spawnArea2(){
        areaMinX = 101;
        areaMaxX = 147;
        areaMinZ = 333;
        areaMaxZ = 367;
    }
    void humanArea1spawnArea3(){
        areaMinX = 6;
        areaMaxX = 25;
        areaMinZ = 229;
        areaMaxZ = 379;
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
