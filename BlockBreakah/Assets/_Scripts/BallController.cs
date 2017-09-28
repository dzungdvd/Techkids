using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class BallController : MonoBehaviour {
	public float ballSpeed;
	public float forceMultipler;

	public Transform spritePivot;

	private Rigidbody2D rgBody;
	private Animator anim;
	private TrailRenderer trailRenderer;

	void Awake(){
		rgBody = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();
		trailRenderer = GetComponent<TrailRenderer> ();
	}

	void Start () {
		rgBody.velocity = new Vector2 (1, 1).ScaleTo (ballSpeed);
	}

	void Update(){
		rgBody.velocity = rgBody.velocity.ScaleTo (ballSpeed);
		spritePivot.localRotation = Quaternion.Euler(
			0,
			0,
			Vector2.SignedAngle(Vector2.up, rgBody.velocity)
		);
	}

	void OnCollisionEnter2D(Collision2D coll){
		anim.SetTrigger ("OnHit");
		//trailRenderer.material.color = Color.red;

		Camera.main.GetComponent<CameraShaker> ().Shake (rgBody.velocity);

		if (coll.gameObject.tag == "Paddle") {
			float offsetX = transform.position.x - coll.transform.position.x;
			rgBody.AddForce (Vector2.right * offsetX * forceMultipler);
		}

		if (coll.gameObject.tag == "Wall") {
			GameplayManager.Instance.WallFlash ();
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (Mathf.Abs(rgBody.velocity.y) < 200f) {
			rgBody.velocity = rgBody.velocity.WithY (Mathf.Sign (rgBody.velocity.y) * 200f).ScaleTo (ballSpeed);
		}
	}
}
