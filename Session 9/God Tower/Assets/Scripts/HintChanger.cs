using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintChanger : MonoBehaviour {

	public List<GameObject> hintsList;
	public Button hintButton;

	int hintCurrentIndex = 0;

	public void OnHintButtonClick()
	{
		hintCurrentIndex += 1;

		if (hintCurrentIndex == hintsList.Count - 1) {
			hintButton.transform.localScale = new Vector3 (-1, 1, 1);
		} else {
			hintButton.transform.localScale = new Vector3 (1, 1, 1);
		}

		if (hintCurrentIndex == hintsList.Count) {
			hintCurrentIndex = 0;
		}

		for (int i = 0; i < hintsList.Count; i++) {
			if (i == hintCurrentIndex) {
				hintsList [i].gameObject.SetActive (true);
			} else {
				hintsList [i].gameObject.SetActive (false);
			}
		}
		
	}

}
