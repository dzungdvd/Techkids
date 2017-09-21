using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour {

	float radius;

	public float angleSpeed = 1;
	float horizontalLength;
	float verticalLength;

	float angle;
	Vector2 radiusVector;
	GameObject planet;

	SpriteRenderer sr;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		sr.enabled = false;
		planet = transform.GetChild (0).gameObject;
		horizontalLength = 1;
		verticalLength = 1;
		radiusVector = planet.transform.position - transform.position;
		radius = radiusVector.magnitude;
		StartCoroutine (rotate());

	}

	IEnumerator rotate(){
		while (true){
			angle = (angle + angleSpeed) % 360;
			yield return null;
		}
	}
		
	void Update () {
		radiusVector = rotate (Vector2.right, angle) * radius;
		planet.transform.position = (Vector2) transform.position + radiusVector;
	}

	public Vector2 rotate(Vector2 v,float angle){
		float rad = angle * Mathf.Deg2Rad;
		float sin = Mathf.Sin (rad);
		float cos = Mathf.Cos (rad);
		return new Vector2 ((cos * v.x - sin * v.y)*horizontalLength, (sin * v.x + cos * v.y)*verticalLength);
	}
}