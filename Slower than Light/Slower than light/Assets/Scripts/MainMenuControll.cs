using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControll : MonoBehaviour {
	public GameObject levelMenu;
	public GameObject mainMenu;

	public int level;
	// Use this for initialization
	void Start () {
		if (level == 0) {
			levelMenu.gameObject.SetActive (false);
		}
	}

	public void PlayButton () {
		
		mainMenu.gameObject.SetActive (false);
		levelMenu.gameObject.SetActive (true);
	}
		
	public void levelButton () {
		SceneManager.LoadScene (level);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
