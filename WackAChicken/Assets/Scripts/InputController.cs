using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	public string horizontalAxesName;
	public string verticalAxesName;
	public string hammerAxesName;

	public System.Action<Vector2> OnMove;
	public System.Action OnHammer;

	void Update()
	{
		if(OnMove != null){
			OnMove(new Vector2(
				Input.GetAxis(horizontalAxesName),
				Input.GetAxis(verticalAxesName)
			));
		}

		if(Input.GetButtonDown(hammerAxesName) && OnHammer != null){
			OnHammer();
		}
	}
}
