using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {
	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode dash;
	public Vector2 currentFace = Vector2.right;

	
	public Action<Vector2> OnMove;
	public Action OnJump;
	public Action OnDash;
	
	void Update () {
		if(Input.GetKey(left)){
			if(OnMove != null) OnMove(Vector2.left);
			currentFace = Vector2.left;
		}
		else if(Input.GetKey(right)){
			if(OnMove != null) OnMove(Vector2.right);
			currentFace = Vector2.right;
		}
		else{
			if(OnMove != null) OnMove(Vector2.zero);
		}

		if(Input.GetKeyDown(jump)){
			if(OnJump != null) OnJump();
		}

		if(Input.GetKeyDown(dash)){
			if(OnDash != null) OnDash();
		}
	}
}
