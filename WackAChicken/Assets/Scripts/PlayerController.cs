using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(Controller2D))]
public class PlayerController : MonoBehaviour {
	public float movementSpeed;
	public LayerMask chickenMask;
	public float hitRadius = 10f;
	private InputController inputController;
	private Controller2D controller2D;
	private Animator anim;
	private Vector2 faceDirection;

	private Vector2 currentVelocity = Vector2.zero;
	private Vector2 input;
	void Start () {
		inputController = GetComponent<InputController>();
		controller2D = GetComponent<Controller2D>();
		anim = GetComponent<Animator>();
		inputController.OnMove += OnMove;
		inputController.OnHammer += OnHammer;
		faceDirection = Vector2.down;
	}

	void OnDestroy()
	{
		inputController.OnMove -= OnMove;
		inputController.OnHammer -= OnHammer;
	}
	
	void OnMove(Vector2 input){
		this.input = input;
		currentVelocity = input * movementSpeed;
		if (input != Vector2.zero) {
			faceDirection = input.normalized;
		}
	}

	void OnHammer(){
		anim.SetTrigger("Hammer");
	}

	public void HitCheck(){
		
		Vector2 hitLocation = new Vector2 ();

		if (faceDirection.normalized.x > 0.7f) {
			hitLocation = new Vector2(20, 0);
		} else if (faceDirection.normalized.x < -0.7f) {
			hitLocation = new Vector2(-20, 0);
		} else if (faceDirection.normalized.y > 0.7f) {
			hitLocation = new Vector2(4, 10);
		} else if (faceDirection.normalized.y < -0.7f) {
			hitLocation = new Vector2(-4, -10);
		}

		Collider2D[] chickens = Physics2D.OverlapCircleAll(
			transform.position.xy() + hitLocation,
			hitRadius,
			chickenMask
		);

		Debug.DrawLine (
			transform.position.xy() + hitLocation + Vector2.left.ScaleTo(hitRadius),
			transform.position.xy() + hitLocation + Vector2.right.ScaleTo(hitRadius),
			Color.yellow,
			1
		);
		Debug.DrawLine (
			transform.position.xy() + hitLocation + Vector2.up.ScaleTo(hitRadius),
			transform.position.xy() + hitLocation + Vector2.down.ScaleTo(hitRadius),
			Color.yellow,
			1
		);

		foreach (Collider2D chicken in chickens)
		{
			chicken.GetComponent<ChikenController>().Die();
		}
	}
	
	void Update () {
		transform.position = controller2D.Move(transform.position, currentVelocity * Time.deltaTime).position;
		anim.SetFloat("X", input.x);
		anim.SetFloat("Y", input.y);
	}
}
