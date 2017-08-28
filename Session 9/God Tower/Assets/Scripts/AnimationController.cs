using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	public float moveSpeed = 2f;
	public float distance = 10f;

	// Use this for initialization
	void Start () {
		StartCoroutine (MoveRight ());
	}

	IEnumerator MoveRight()
	{
		float distanceMoved = 0f;
		while (distanceMoved < distance) {
			transform.position = new Vector3(
				transform.position.x + moveSpeed * Time.deltaTime,
				transform.position.y, 
				transform.position.z
			);
			distanceMoved += moveSpeed * Time.deltaTime;
			yield return null;
		}
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			Debug.Log("B pressed");
		}
	}
}
