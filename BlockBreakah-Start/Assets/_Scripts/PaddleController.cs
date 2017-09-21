using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	public float paddleSpeed;
	Vector3 mouseWorldPos;
	float paddlePosX;
	float targetPaddlePosX;

	void Update () {
		mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		targetPaddlePosX = Mathf.Clamp (mouseWorldPos.x, -521f, 521f);
		if (Mathf.Abs (targetPaddlePosX - transform.position.x) > paddleSpeed * Time.deltaTime) {
			paddlePosX = transform.position.x+(targetPaddlePosX-transform.position.x)*paddleSpeed*Time.deltaTime;
		} else {
			paddlePosX = targetPaddlePosX;
		}

		transform.position = new Vector2 (paddlePosX, transform.position.y);
	}
}
