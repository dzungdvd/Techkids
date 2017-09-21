using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	Vector3 startScale;
	Color startColor;
	Color endColor;
	float t;
	SpriteRenderer sr;

	public AudioClip explosionSound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		t = 0f;
		startScale = transform.localScale;
		startColor = new Color (1f, 1f, 1f, 1f);
		endColor = new Color (1f, 1f, 1f, 0f);

		sr = GetComponent<SpriteRenderer> ();
		sr.color = new Color (1f, 1f, 1f, 1f);
		audioSource = GetComponent<AudioSource>();
		audioSource.PlayOneShot(explosionSound, 0.7F);

	}

	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.Lerp(startScale, startScale * 10, t);
		sr.color = Color.Lerp (startColor, endColor, t);
		t += 1.0f * Time.deltaTime;
		Destroy (gameObject, 3f);
	}
}
