using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {

	public float MaxFuel;
	public float CurrentFuel;

	// Use this for initialization
	void Start () 
	{
		CurrentFuel = MaxFuel;
	}
	
	// Update is called once per frame
	void OnCollisonEnter(Collison col)
	{
		if (col.gameObject.name == "BuffFuel") {
			CurrentFuel += 50;
			if (CurrentFuel > 0)
				CurrentFuel = 100;
				
		} 
	}


	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			LostFuel ();
		}
	}
	void LostFuel()
	{
		CurrentFuel -= 25;
		if (CurrentFuel < 0)
			CurrentFuel = 0;
		transform.localScale = new Vector3 ((CurrentFuel/MaxFuel), 1, 1);
	}
}
