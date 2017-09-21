using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour {

	public float spinSpeed;
	float rotation;
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0f, 0f, rotation);
		rotation += spinSpeed;
	}
}
