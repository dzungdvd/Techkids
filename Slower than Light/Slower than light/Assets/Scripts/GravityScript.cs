using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour {
	
	public float enginePower;
	GameObject[] planets;
	Vector2 gravity;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		planets = GameObject.FindGameObjectsWithTag("planet");
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update () {
		//gravity
		foreach (GameObject planet in planets) {
			gravity = planet.transform.position - gameObject.transform.position;
			float planetmass = planet.GetComponent<PlanetScript> ().mass;
			rb.AddForce (gravity.normalized * planetmass * 100 * Time.deltaTime / gravity.sqrMagnitude);
		}
		//engine
		if (Input.GetButton("Fire1")) {
			print ("Fire1 pressed");
			rb.AddForce (rb.transform.up * enginePower * 0.5f * Time.deltaTime);
		}
		//rotation
		Vector3 screenMousePos = Input.mousePosition;
		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint (screenMousePos);
	}
}