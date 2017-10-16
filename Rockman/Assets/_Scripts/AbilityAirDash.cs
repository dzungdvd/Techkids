using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAirDash : MonoBehaviour {
	
	private PlayerController playerController;
	private InputController inputController;
	
	void Awake()
	{
		inputController = GetComponent<InputController>();
		playerController = GetComponent<PlayerController>();

		inputController.OnDash += OnDash;
	}

	void OnDestroy()
	{
		inputController.OnDash -= OnDash;
	}
	void OnDash(){
		if(!playerController.currentState.collidingBottom && playerController.airborneAbilityReady){
			playerController.antiGravity = true;
			playerController.Dash();
			playerController.airborneAbilityReady = false;
			playerController.currentVelocity.y = 0;
			StartCoroutine (DashCoroutine());
		}
	}
	IEnumerator DashCoroutine(){
		yield return new WaitForSeconds(playerController.dashTime);
		playerController.antiGravity = false;
	}
}
