using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour {
	public float ballSpeed;
	public float minAngle;
	private Rigidbody2D rgBody;

	void Awake(){
		rgBody = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		rgBody.velocity = new Vector2 (1, 1).ScaleTo (ballSpeed);

	}
	void Update(){
		rgBody.velocity = rgBody.velocity.ScaleTo (ballSpeed);
	}
}
