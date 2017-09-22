using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	GameObject[] blocks;
	int blocksLeft;
	int thisLevel;

	// Use this for initialization
	void Start () {
		blocks = GameObject.FindGameObjectsWithTag ("block");
		blocksLeft = blocks.Length;
		string thisSceneName = SceneManager.GetActiveScene ().name;
		thisLevel = Int32.Parse (thisSceneName.Substring (5));
	}

	public void BlockCountChange(int amount)
	{
		blocksLeft = blocksLeft + amount;
	}
	
	// Update is called once per frame
	void Update () {
		if (blocksLeft == 0) {
			SceneManager.LoadSceneAsync ("level" + (thisLevel+1).ToString());
		}
	}
}
