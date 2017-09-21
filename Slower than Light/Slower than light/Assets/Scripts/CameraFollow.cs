using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow: MonoBehaviour {

	public Transform target;
	Camera camComponent;
	bool followEnabled = false;

	// Use this for initialization
	void Start () {
		camComponent = gameObject.GetComponent<Camera> ();
		camComponent.orthographicSize = 15; // Cho nguoi choi xem map;
		StartCoroutine (scaleBack ()); // Bat dau phong to map;
	}

	IEnumerator scaleBack() { // Code phong to map;
		int orthSizeDest = 5;
		yield return new WaitForSeconds (2);
		while (camComponent.orthographicSize > orthSizeDest) {
			camComponent.orthographicSize -= 1;
			yield return null;
		}
		if (camComponent.orthographicSize == orthSizeDest) {
			followEnabled = true;
		}
		Debug.Log (camComponent.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () { 
		
		if (Input.GetKey (KeyCode.X)){
			camComponent.orthographicSize = 10; // Nhan X thu nho map;
		}
		if (Input.GetKey (KeyCode.Z)) {
			camComponent.orthographicSize = 5; // Nhan Z phong to map;
		}
	}

	void LateUpdate () {
		if (followEnabled) {
			transform.localPosition = new Vector3 (target.position.x, target.position.y, transform.position.z); // Dung khi chua co map hoan chinh
			//transform.localPosition = new Vector3 (Mathf.Clamp(target.position.x,minWidth,maxWidth), Mathf.Clamp(target.position.y,minHeigth,maxHeigth), transform.localPosition); Dung khi co map hoan chinh
		}
	}

}