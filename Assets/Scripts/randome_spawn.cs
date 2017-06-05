using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randome_spawn : MonoBehaviour {

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

	void Start()
	{
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
