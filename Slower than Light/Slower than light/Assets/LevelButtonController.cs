using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonController : MonoBehaviour {

	int thisLevel;
	string thisButtonName;

	public void LoadLevel()
	{
		thisButtonName = transform.GetChild (0).GetComponent<Text> ().text;
		thisLevel = Int32.Parse (thisButtonName);
		string levelName = "0.2lv " + (thisLevel).ToString();
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}
}
