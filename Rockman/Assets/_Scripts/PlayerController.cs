using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(Controller2D))]
public class PlayerController : MonoBehaviour {
	public float movementSpeed;

	private float currentSpeed ;
	public float jumpSpeed;
	public float dashSpeed;
	public float dashTime;
	public float maxFallSpeed;
	public bool antiGravity = false;

	public PlayerState currentState;
	
	private InputController inputController;
	private Controller2D controller2D;

	public Vector2 currentVelocity = Vector2.zero;

	public bool airborneAbilityReady = true;
	public bool wallGrab = false;

	void Awake()
	{
		inputController = GetComponent<InputController>();
		controller2D = GetComponent<Controller2D>();

		inputController.OnMove += OnPlayerMove;
		inputController.OnJump += OnJump;
		inputController.OnDash += OnDash;
		currentSpeed = movementSpeed;
	}

	void OnDestroy()
	{
		inputController.OnMove -= OnPlayerMove;
		inputController.OnJump -= OnJump;
		inputController.OnDash -= OnDash;
	}

	void OnPlayerMove(Vector2 direction){
		currentVelocity.x = direction.x * currentSpeed;
	}

	void OnJump(){
		if(currentState.collidingBottom) Jump();
	}

	void OnDash(){
		
	}
	public void Dash(){
		inputController.OnMove -= OnPlayerMove;
		currentSpeed = dashSpeed;
		currentVelocity.x = currentSpeed * inputController.currentFace.x;
		StartCoroutine(DashCoroutine());
	}
	IEnumerator DashCoroutine(){

		yield return new WaitForSeconds(dashTime);
		currentSpeed = movementSpeed;
		inputController.OnMove += OnPlayerMove;

	}
	public void Jump(){
		currentVelocity.y = jumpSpeed;
	}

	void Update () {

		if(!antiGravity && (currentVelocity.y > maxFallSpeed)) 
			currentVelocity += Physics2D.gravity * Time.deltaTime;

		currentState = controller2D.Move(transform.position, currentVelocity*Time.deltaTime);
		transform.position = currentState.position;
		
		if(currentState.collidingTop) currentVelocity.y = 0;

		if (currentState.collidingBottom) {
			currentVelocity.y = 0;
			airborneAbilityReady = true;
		}
	}
}
