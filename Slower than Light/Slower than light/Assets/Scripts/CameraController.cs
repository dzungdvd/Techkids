using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

	GameObject player;
	Vector3 originalPos;
	public float parallax;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		originalPos = transform.position;
		parallax = Mathf.Clamp (parallax, 0, 1);
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			(player.transform.position.x + originalPos.x) * parallax, 
			(player.transform.position.y + originalPos.y) * parallax, 
			transform.position.z);
	}
}
