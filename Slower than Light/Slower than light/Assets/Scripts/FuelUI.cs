using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour {

	public Image fuelBar;
	public ShipController player;

	public AudioSource audioSource;
	public AudioClip engineOff;
	public AudioClip engineOn;

	// Use this for initialization
	void Start () {
		fuelBar = GameObject.Find ("CurrentFuel").GetComponent<Image>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<ShipController> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	void Update()
	{
		fuelBar.transform.localScale = new Vector3 ((player.currentHeat/player.maxHeat), 1, 1);
		if (player.overheat == true ) {
			fuelBar.color = Color.red;
		} else {
			fuelBar.color = Color.Lerp (Color.white, Color.yellow, (player.currentHeat / player.maxHeat));
		}
	}
}
