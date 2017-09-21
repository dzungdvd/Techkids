using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubgoalController : MonoBehaviour {

	public bool complete;
	SpriteRenderer sr;
	AudioSource audioSource;
	public AudioClip getItem;

	void Start(){
		audioSource = GetComponent<AudioSource> ();
		sr = GetComponent<SpriteRenderer> ();
		complete = false;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if ((col.gameObject.tag == "Player") && (complete == false)){
			audioSource.PlayOneShot (getItem, 1.0f);
			complete = true;
			sr.enabled = false;
		}
	}
}
