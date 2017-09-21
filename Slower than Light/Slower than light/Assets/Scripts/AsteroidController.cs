using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	float rotation;
	float randomSpin;
	public float maxSpinSpeed;

	void Start () {
		randomSpin = Random.Range (-maxSpinSpeed, maxSpinSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0f, 0f, rotation);
		rotation += randomSpin;
	}
}
