using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControll : MonoBehaviour {
	public GameObject levelMenu;
	public GameObject mainMenu;
	public GameObject creditMenu;

	public GameObject levelPanel;
	public GameObject mainMenuPanel;
	public GameObject creditPanel;

	// Use this for initialization
	void Start () {
		levelMenu.gameObject.SetActive (false);
		levelPanel.gameObject.SetActive (false);

		creditMenu.gameObject.SetActive (false);
		creditPanel.gameObject.SetActive (false);

	}

	public void PlayButton () {
		mainMenu.gameObject.SetActive (false);
		creditMenu.gameObject.SetActive (false);

		creditPanel.gameObject.SetActive (false);
		mainMenuPanel.gameObject.SetActive (false);

		levelMenu.gameObject.SetActive (true);
		levelPanel.gameObject.SetActive (true);
	}

	public void CreditButton () {
		creditMenu.gameObject.SetActive (true);
		creditPanel.gameObject.SetActive (true);

		mainMenuPanel.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (false);

		levelMenu.gameObject.SetActive (false);
		levelPanel.gameObject.SetActive (false);
	}

	public void BackBut () {
		creditMenu.gameObject.SetActive (false);
		creditPanel.gameObject.SetActive (false);

		mainMenuPanel.gameObject.SetActive (true);
		mainMenu.gameObject.SetActive (true);

		levelMenu.gameObject.SetActive (false);
		levelPanel.gameObject.SetActive (false);
	}
}
