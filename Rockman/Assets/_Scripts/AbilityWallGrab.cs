using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWallGrab : MonoBehaviour {
	public float wallKickVerticalSpeed;
	public float wallKickHorizontalSpeed;
	public float wallSlideSpeed;

	private PlayerController playerController;
	private InputController inputController;
	private Vector2 wallDirection;

	void Awake()
	{
		inputController = GetComponent<InputController>();
		playerController = GetComponent<PlayerController>();
		inputController.OnMove += WallGrab;
		inputController.OnJump += WallKick;
	}

	void OnDestroy()
	{
		inputController.OnMove -= WallGrab;
		inputController.OnJump -= WallKick;
	}

	void WallGrab(Vector2 placeHolder){
		if (playerController.currentState.collidingBottom == false
			&& (playerController.currentState.collidingLeft ||
			playerController.currentState.collidingRight)
		) 
		{
			playerController.wallGrab = true;
			playerController.airborneAbilityReady = true;
			playerController.currentVelocity.y = Mathf.Clamp (playerController.currentVelocity.y, wallSlideSpeed, 0);
		} else {
			playerController.wallGrab = false;
		}
	}

	void WallKick(){
		if (playerController.wallGrab) {
			playerController.currentVelocity.y = wallKickVerticalSpeed;
			playerController.currentVelocity.x = wallKickHorizontalSpeed * -inputController.currentFace.x;
		}
	}
}
