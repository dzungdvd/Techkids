using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour {

	public Text levelText;
	public InputField inputField;
	public Button submitButton;
	public Text hintText;

	public string levelContent = "LEVELS";
	public string levelNumber;
	public string levelAnswer;

	string answer;

	// Use this for initialization
	void Start () {
		levelText.text = levelContent;
		StartCoroutine (ChangeLevelTextRoutine ());
	}

	public void GetInput()
	{
		answer = inputField.text;
		CheckAnswer(answer);
	}

	public void CheckAnswer(string answer)
	{
		if (answer == levelAnswer) {
			hintText.text = "Yay!";
			//TODO: Change scene
		} else {
			hintText.text = "Wrong answer!";
			hintText.color = Color.red;
			inputField.text = "";
			inputField.ActivateInputField ();
		}
	}

	IEnumerator ChangeLevelTextRoutine()
	{
			levelText.text = levelContent;
			yield return new WaitForSeconds (2f);
			levelText.text = levelNumber;
			yield return new WaitForSeconds (2f);
			StartCoroutine (ChangeLevelTextRoutine ());
	}

	// Update is called once per frame
//	void Update () {
//		if (Mathf.RoundToInt(Time.timeSinceLevelLoad) % 2 == 0) {
//			levelText.text = levelContent;
//		} else {
//			levelText.text = levelNumber;
//		}
//	}
}
