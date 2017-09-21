using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		print ("Collision detected!");
		if (col.gameObject.tag == "planet") {
			Debug.Log ("You Lose");
//		} else if (col.gameObject.tag == "Rock") {
//			Debug.Log ("You Lose");
		}
	}
}
