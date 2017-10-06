using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float acceleration;
	Rigidbody2D rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		//movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb.AddForce (movement * acceleration);
		
	}
}
