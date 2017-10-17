using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

	public static GameplayManager instance;

	public List<GameObject> cabbageList;

	void Awake(){
		instance = this;
	}
	void Start () {
		cabbageList.AddRange(GameObject.FindGameObjectsWithTag("cabbage"));
	}
	
	public GameObject GetRandomCabbage(){
		if (cabbageList.Count == 0) return null;
		GameObject cabbage = cabbageList[Random.Range(0, cabbageList.Count)];
		return cabbage;
	}

	void Update () {
		
	}
}
