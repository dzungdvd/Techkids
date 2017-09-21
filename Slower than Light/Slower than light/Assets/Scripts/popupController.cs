using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class popupController : MonoBehaviour {

	string thisSceneName;
	int thisLevel;

	GameObject popupWin;
	GameObject popupLose;
	ShipController player;
	GoalController goal;

	AudioSource audioSource;
	public AudioClip bgm;
	public AudioClip winSound;
	public AudioClip loseSound;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<ShipController>();
		goal = GameObject.Find("MainGoal").GetComponent<GoalController>();
		popupWin = GameObject.Find ("popupWin");
		popupLose = GameObject.Find ("popupLose");
		popupWin.gameObject.SetActive (false);
		popupLose.gameObject.SetActive (false);

		thisSceneName = SceneManager.GetActiveScene ().name;
		thisLevel = Int32.Parse (thisSceneName.Substring (6));

		audioSource = GetComponent<AudioSource>();
		audioSource.clip = bgm;
		audioSource.volume = 0.3f;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.alive == false) {
			StartCoroutine(LoseMenu());
			player.alive = true;
		}
		if (goal.levelComplete == true) {
			StartCoroutine(WinMenu());
			goal.levelComplete = false;
		}
	}

	IEnumerator LoseMenu()
	{
		audioSource.Stop();
		yield return new WaitForSeconds(1.5f);
		popupLose.gameObject.SetActive (true);
		audioSource.PlayOneShot(loseSound, 1.0F);
		print ("You lose");
		yield break;
	}

	IEnumerator WinMenu()
	{
		audioSource.Stop();
		yield return new WaitForSeconds(0.5f);
		popupWin.gameObject.SetActive (true);
		audioSource.PlayOneShot(winSound, 1.0F);
		popupWin.GetComponentInChildren<Text> ().text = 
			"Level complete! " + "Bonus found: " 
			+ goal.subGoalComplete.ToString() + "/"
			+ goal.subGoalTotal.ToString();
		goal.levelComplete = false;
		print ("You win");
		yield break;
	}

	public void Retry()
	{
		string levelName = "0.2lv " + thisLevel.ToString();
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}

	public void NextLevel()
	{
		string levelName = "0.2lv " + (thisLevel + 1).ToString();
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}

	public void MainMenu()
	{
		string levelName = "0.2MainMenu";
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}
}
