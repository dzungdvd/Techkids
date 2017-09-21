using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public float enginePower;
	public float currentHeat;
	public float maxHeat;
	public bool overheat;

	public bool alive;

	public GameObject explosion;
	GameObject exhaust;
	GameObject[] planets;

	Vector2 gravity;
	Rigidbody2D rb;

	bool thrusterOn;
	float thrusterOnStartTime;

	AudioSource[] audioSources;
	public AudioClip engineOff;
	public AudioClip engineOn;

	// Use this for initialization
	void Start () {
		planets = GameObject.FindGameObjectsWithTag("planet");
		rb = gameObject.GetComponent<Rigidbody2D>();
		exhaust = GameObject.Find("exhaust");
		exhaust.gameObject.SetActive (false);

		audioSources = GetComponents<AudioSource>();
		audioSources[0].Play();
		audioSources[0].mute = true;

		currentHeat = 0f;
		overheat = false;
		alive = true;
		thrusterOn = false;
	}

	void Update () {
		GravityPull ();
		RotateShip ();
		ThrusterCheck ();
		OverheatCheck ();
	}

	void ThrusterCheck()
	{
		if (Input.GetButton ("Fire1")) {
			if (overheat == false) {
				thrusterOn = true;
			}
		} else {
			thrusterOn = false;
		}

		if (thrusterOn == true) {
			rb.AddForce (rb.transform.up * enginePower * 1f * Time.deltaTime);
			ChangeHeat (1);
			exhaust.gameObject.SetActive (true);
			audioSources [0].mute = false;
		} else {
			exhaust.gameObject.SetActive (false);
			audioSources [0].mute = true;
			ChangeHeat (-30f * Time.deltaTime);
		}
	}

	void OverheatCheck(){
		if (currentHeat >= maxHeat) {
			thrusterOn = false;
			overheat = true;
			audioSources[1].PlayOneShot(engineOff, 1.0F);
		}
		if ((currentHeat == 0) && (overheat == true)) {
			overheat = false;
			audioSources[1].PlayOneShot(engineOn, 1.0F);
		}
		if (overheat == true) {
			ChangeHeat (-30f * Time.deltaTime);
		}
	}

	public void ChangeHeat(float amount)
	{
		currentHeat += amount;
		currentHeat = Mathf.Clamp (currentHeat, 0, maxHeat);
	}

	void RotateShip()
	{
		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 shipToMouse = worldMousePos - transform.position;
		float rotationZ = Mathf.Atan2(shipToMouse.y, shipToMouse.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotationZ - 90f);
	}

	void GravityPull()
	{
		foreach (GameObject planet in planets) {
			gravity = planet.transform.position - gameObject.transform.position;
			float planetmass = planet.GetComponent<PlanetScript>().mass;
			rb.AddForce (gravity.normalized * planetmass * 10f * Time.deltaTime / gravity.sqrMagnitude);
		}
	}

	void Death()
	{
		GameObject explosionClone = Instantiate (explosion, transform.position, transform.rotation);
		alive = false;
		gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "planet") {
			Death ();
		}
		if (col.gameObject.tag == "blocker") {
			Death ();
		}
		if (col.gameObject.tag == "goal") {
			gameObject.SetActive (false);
		}
	}

}