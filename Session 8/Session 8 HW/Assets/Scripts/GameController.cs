using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int minNumber;
	public int maxNumber;
	public Text displayText;
	public Button lower;
	public Button higher;
	public Button yes;
	public Button play;

	float guessNumber;
	float lowerBound;
	float upperBound;
	int guessCount;

	// Use this for initialization
	void Start () {
		minNumber = 1;
		maxNumber = 4;
		Instruction ();
	}

	public void AnswerLower()
	{
		upperBound = guessNumber;
		Guess ();
	}

	public void AnswerHigher()
	{
		lowerBound = guessNumber;
		Guess ();
	}

	public void AnswerYes()
	{
		displayText.text = string.Format("Oh yeah! It takes me {0} tries. Play again?", guessCount);
		SetButton ("notplaying");
	}

	public void Cheat()
	{
		displayText.text = string.Format("Cheating is for the weak.");
		SetButton ("notplaying");
	}

	public void Guess()
	{
		guessCount++;
		guessNumber = (lowerBound + upperBound) / 2;
		if (upperBound - lowerBound > 0.5) {
			displayText.text = string.Format ("Is {0} your number?", Mathf.RoundToInt (guessNumber));
			print (lowerBound);
			print (guessNumber);
			print (upperBound);
		} else {
			Cheat ();
		}
	}

	public void NewGame()
	{
		SetButton ("playing");
		lowerBound = minNumber;
		upperBound = maxNumber;
		guessCount = 0;
		Guess ();
	}

	public void Instruction()
	{
		displayText.text = string.Format("Think of an integer between {0} and {1} and I'll guess that number.", minNumber, maxNumber);
		SetButton ("notplaying");
	}

	public void SetButton(string state)
	{
		if (state == "playing") {
			play.gameObject.SetActive (false);
			lower.gameObject.SetActive (true);
			higher.gameObject.SetActive (true);
			yes.gameObject.SetActive (true);
		}
		if (state == "notplaying") {
			play.gameObject.SetActive (true);
			lower.gameObject.SetActive (false);
			higher.gameObject.SetActive (false);
			yes.gameObject.SetActive (false);
		}
	}
}
