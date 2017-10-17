using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour {

	public GameObject chickenPrefab;
	public float spawnInterval;
	public float spawnLocationVertical;
	public float spawnLocationHorizontal;

	private float lastSpawnTime = 0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		while (Time.time > lastSpawnTime + spawnInterval){
			int sign = Random.value > 0.5f ? -1 : 1;
			Vector2 spawnLocation = new Vector2(spawnLocationHorizontal * sign, Random.Range(-spawnLocationVertical, spawnLocationVertical));
			SpawnChicken(spawnLocation);
			lastSpawnTime = Time.time;
		}
	}

	void SpawnChicken(Vector2 pos){
		Instantiate(chickenPrefab, pos, Quaternion.identity);
	}
}
