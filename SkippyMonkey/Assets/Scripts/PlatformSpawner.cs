using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
	public GameObject platformPrefab;
	public float startingY;
	public float platformSpacing;

	private int currentPlatformIndex = 0;

	private float platformSpawnPadding;
	private float screenHalfHeight;

	void Start () {
		screenHalfHeight = Camera.main.orthographicSize;
		platformSpawnPadding = Camera.main.GetComponent<TKCameraResizer>().deviceHalfWidth - 110;
		while(startingY + currentPlatformIndex * platformSpacing < screenHalfHeight){
			SpawnPlatform();
		}
	}

	void Update () {
		if(startingY + currentPlatformIndex * platformSpacing < Camera.main.transform.position.y + screenHalfHeight){
			SpawnPlatform();
		}
	}

	void SpawnPlatform(){
		GameObject obj = ObjectPooler.current.GetPooledObject();
		if (obj == null)
			return;
		obj.transform.position = new Vector3 (Random.Range (-platformSpawnPadding, platformSpawnPadding), startingY + currentPlatformIndex * platformSpacing, 0);
		
		currentPlatformIndex++;
	}
}
