using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(InputController))]
public class AbilityDoubleJump : MonoBehaviour {
	private PlayerController playerController;
	private InputController inputController;
	
	void Awake()
	{
		inputController = GetComponent<InputController>();
		playerController = GetComponent<PlayerController>();

		inputController.OnJump += OnJump;
	}

	void OnDestroy()
	{
		inputController.OnJump -= OnJump;
	}
	
	void OnJump(){
		if(!playerController.currentState.collidingBottom 
			&& !playerController.wallGrab
			&& playerController.airborneAbilityReady){
			playerController.airborneAbilityReady = false;
			playerController.Jump();
		}
	}
}
