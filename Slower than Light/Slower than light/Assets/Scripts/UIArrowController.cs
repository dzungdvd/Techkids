using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArrowController : MonoBehaviour {

	public float distanceToDisappear;
	GameObject player;
	GameObject goal;
	GameObject arrow;
	Vector3 playerToGoal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		goal = GameObject.Find("MainGoal");
		arrow = GameObject.Find ("arrowSprite");
	}

	// Update is called once per frame
	void Update () {
		playerToGoal = goal.transform.position - player.transform.position;
		if (playerToGoal.sqrMagnitude >= distanceToDisappear) {
			arrow.gameObject.SetActive (true);
			float rotationZ = Mathf.Atan2 (playerToGoal.y, playerToGoal.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0f, 0f, rotationZ);
		} else {
			arrow.gameObject.SetActive (false);
		}

	}
}
