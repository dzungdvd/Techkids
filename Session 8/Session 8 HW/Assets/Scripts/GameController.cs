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

	int guessNumber;
	int lowerBound;
	int upperBound;
	int guessCount;

	// Use this for initialization
	void Start () {
		minNumber = 1;
		maxNumber = 10000;

		displayText.text = string.Format("Think of an integer between {0} and {1} and I'll guess that number.", minNumber, maxNumber);
		SetButton ("notplaying");
	}

	public void AnswerLower()
	{
			upperBound = guessNumber - 1;
			Guess ();
	}

	public void AnswerHigher()
	{
			lowerBound = guessNumber + 1;
			Guess ();
	}

	public void AnswerYes()
	{
		displayText.text = string.Format("Oh yeah! It takes me {0} tries. Play again?", guessCount);
		SetButton ("notplaying");
	}

	public void Guess()
	{
		if (upperBound < lowerBound) {
			displayText.text = string.Format ("Cheating is for the weak.");
			SetButton ("notplaying");
		} else {
			guessCount++;
			guessNumber = (lowerBound + upperBound) / 2;
			displayText.text = string.Format ("Is {0} your number?", guessNumber);
		}
		print (lowerBound);
		print (guessNumber);
		print (upperBound);
	}

	public void NewGame()
	{
		SetButton ("playing");
		lowerBound = minNumber;
		upperBound = maxNumber;
		guessCount = 0;
		Guess ();
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
