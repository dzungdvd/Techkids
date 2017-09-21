using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public GameObject credit;
	public GameObject levels;

	// Use this for initialization
	void Start () {
		credit.SetActive (false);
		levels.SetActive (false);
	}

	public void ToggleCredit()
	{
		Toggle (credit);
	}

	public void ToggleLevels()
	{
		Toggle (levels);
	}

	void Toggle(GameObject menu)
	{
		if (menu.activeSelf == true) {
			menu.SetActive(false);
		} else {
			menu.SetActive(true);
		}
	}
}
