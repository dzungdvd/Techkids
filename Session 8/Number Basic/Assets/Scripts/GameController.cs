using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text displayText;
	public InputField inputField;
	public Button playAgainButton;

	int numberToGuess;
	int guessCount;
	string guess;
	int guessInt;

	// Use this for initialization
	void Start () {
		PlayAgain ();
	}

	public void GetInput()
	{
		guess = inputField.text;
		guessCount++;
		CompareGuess ();
		inputField.text = "";
		inputField.ActivateInputField ();
	}

//	public void CompareGuess()
//	{
//		guessInt = int.Parse (guess);
//		if (guessInt > numberToGuess) {
//			displayText.text = "You guess " + guess + ", which is higher than the right number.";
//		} else if (guessInt < numberToGuess) {
//			displayText.text = "You guess " + guess + ", which is lower than the right number.";
//		} else {
//			displayText.text = "You guess the right number. It takes you " + guessCount + " times.";
//			playAgainButton.gameObject.SetActive (true);
//		}
//	}

	public void CompareGuess()
	{
		Int32.TryParse (guess, out guessInt);
		if (guessInt != null) {
			if (guessInt > numberToGuess) {
				displayText.text = "You guess " + guess + ", which is higher than the right number.";
			} else if (guessInt < numberToGuess) {
				displayText.text = "You guess " + guess + ", which is lower than the right number.";
			} else {
				displayText.text = "You guess the right number. It takes you " + guessCount + " times.";
				playAgainButton.gameObject.SetActive (true);
			}
		}
	}

	public void PlayAgain()
	{
		numberToGuess = UnityEngine.Random.Range (0, 2);
		displayText.text = "Guess a number between 0 - 2";
		playAgainButton.gameObject.SetActive (false);
		guessCount = 0;
	}
	

}
