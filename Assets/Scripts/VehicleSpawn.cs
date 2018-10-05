using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//adapted from Game Development Lab 1: Unity Basics, author Benno Lueders
public class VehicleSpawn : MonoBehaviour {
    public float spawnWidth = 1;
    public float spawnRate = 1;
    public GameObject CarPrefab;
    float lastSpawnTime = 0;

	
	// Update is called once per frame
	void Update () {
        if(lastSpawnTime+1/spawnRate < Time.time+1){
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(spawnWidth, 0, 0);
            Instantiate(CarPrefab, spawnPosition, Quaternion.identity);

        }
	}
}
