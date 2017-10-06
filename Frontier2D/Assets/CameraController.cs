using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject target;
	public float smoothing = 8f;

	void Start()
		{
			target = GameObject.FindGameObjectWithTag("Player");
		}
		

	void FixedUpdate () {
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Player");
		}
		else
		{
			Vector2 targetCamPos = target.transform.position;
			transform.position = Vector2.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}
