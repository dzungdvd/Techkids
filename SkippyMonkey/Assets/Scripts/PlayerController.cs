using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float movementSpeed = 600f;
	public float jumpSpeed = 1400f;

	private Animator anim;

	private float cameraHalfWidth;

	private Controller2D controller2D;
	private Vector2 currentVelocity = Vector2.zero;

	void Awake()
	{
		controller2D = GetComponent<Controller2D>();
		anim = GetComponent<Animator>();
		cameraHalfWidth = Camera.main.GetComponent<TKCameraResizer>().deviceHalfWidth;
	}

	void Start()
	{
		currentVelocity = Vector2.right * movementSpeed;
	}

	void Update () {
		if (GameController.Instance.playerAlive)
		{
			if(transform.position.x > cameraHalfWidth){
				transform.position = transform.position.WithX(-cameraHalfWidth);
			}

			if(Input.GetButtonDown("Fire1")){
				anim.SetBool("IsGrounded", false);
				currentVelocity = currentVelocity.WithY(jumpSpeed);
			}

			currentVelocity += Physics2D.gravity * Time.deltaTime;

			PlayerState newState = controller2D.Move(transform.position, currentVelocity * Time.deltaTime);
			transform.position = newState.position;
			if(newState.collidingTop) Debug.Log("Colliding Top!");
			if(newState.collidingRight) Debug.Log("Colliding Right!");
			if (newState.collidingRight) {
				GameController.Instance.OnPlayerDeath ();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		anim.SetBool("IsGrounded", true);
	}
}
