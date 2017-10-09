using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	
	void Update () {
		if(target.position.y > transform.position.y){
			transform.position = transform.position.WithY(target.position.y);
		}
	}
}
