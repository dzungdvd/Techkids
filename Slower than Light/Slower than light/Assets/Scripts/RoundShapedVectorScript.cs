using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundShapedVectorScript : MonoBehaviour {


	private Vector2 center;
	public float radius;
	private Vector2 radiusVector;
	private float angle = 270;
	public float angleSpeed = 1;


	// Use this for initialization
	void Start () {
		radiusVector = Vector2.right;
		StartCoroutine (rotate());
		center = transform.parent.position;
	}

	IEnumerator rotate(){

		while (true){
			angle = (angle + angleSpeed) % 360;
			yield return null;

		}
	}

	void OnDrawGizmosSelected() {
		UnityEditor.Handles.color = Color.red;
		UnityEditor.Handles.DrawWireDisc (transform.parent.position, Vector3.forward, radius);

	}

	// Update is called once per frame
	void Update () {
		radiusVector = rotate (Vector2.right, angle) * radius;
		gameObject.transform.position = center + radiusVector;
	}

	public Vector2 rotate(Vector2 v,float angle){
		float rad = angle * Mathf.Deg2Rad;
		float sin = Mathf.Sin (rad);
		float cos = Mathf.Cos (rad);
		return new Vector2 (cos * v.x - sin * v.y, sin * v.x + cos * v.y);
	}
}
