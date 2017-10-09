using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	public float movementSpeed = 600f;
	public float jumpSpeed = 1400f;

	private Rigidbody2D rgBody;
	private Animator anim;

	private float cameraHalfWidth;

	void Awake()
	{
		rgBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		cameraHalfWidth = Camera.main.GetComponent<TKCameraResizer>().deviceHalfWidth;
	}

	void Update () {
		rgBody.velocity = rgBody.velocity.WithX(movementSpeed);
		
		if(transform.position.x > cameraHalfWidth){
			transform.position = transform.position.WithX(-cameraHalfWidth);
		}

		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("IsGrounded", false);
			rgBody.velocity = rgBody.velocity.WithY(jumpSpeed);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		anim.SetBool("IsGrounded", true);
	}
}
