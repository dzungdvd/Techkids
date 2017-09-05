using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collison : MonoBehaviour {

	void OnCollisonEnter(Collison col)
	{
		if (col.gameObject.tag == "planet") {
			Debug.Log ("You Lose");
		} else if (col.gameObject.tag == "Rock") {
			Debug.Log ("You Lose");
		}
	}
}
