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

	private List<GameObject> platformPool = new List<GameObject>();

	void Start () {
		screenHalfHeight = Camera.main.orthographicSize;
		platformSpawnPadding = Camera.main.GetComponent<TKCameraResizer>().deviceHalfWidth - 110;
	}
	
	void Update () {
		if(startingY + currentPlatformIndex * platformSpacing < Camera.main.transform.position.y + screenHalfHeight){
			SpawnPlatform();
		}

		foreach (GameObject platform in platformPool)
		{
			if(platform.transform.position.y < Camera.main.transform.position.y - screenHalfHeight){
				platform.SetActive(false);
			}
		}
	}

	void SpawnPlatform(){
		GameObject platform = GetPlatformFromPool();
		platform.SetActive(true);
		platform.transform.position = new Vector3(
			Random.Range(-platformSpawnPadding, platformSpawnPadding), 
			startingY + currentPlatformIndex * platformSpacing, 
			0
		);
		
		currentPlatformIndex++;
	}

	GameObject GetPlatformFromPool(){
		foreach (GameObject platform in platformPool)
		{
				if(!platform.activeInHierarchy) return platform;
		}

		GameObject newPlatform = Instantiate(platformPrefab); 
			
		platformPool.Add(newPlatform);
		return newPlatform;
	}

	public void SpawnInitialPlatforms(){
		currentPlatformIndex = 0;
		while(startingY + currentPlatformIndex * platformSpacing < screenHalfHeight){
			SpawnPlatform();
		}
	}

	public void DeactiveAllPlatforms(){
		foreach (GameObject platform in platformPool) {
			platform.SetActive(false);
		}
	}
}
