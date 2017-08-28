using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level5Controller : EventTrigger {

	Image thisImage;
	Vector3 offset;

	void Start(){
		thisImage = GetComponent<Image> ();
		float x = Random.Range (-220f, 220f);
		float y = Random.Range (-195f, 195f);
		transform.localPosition = new Vector3 (x,y,transform.localPosition.z);
		thisImage.alphaHitTestMinimumThreshold = 0.5f;
	}

	public override void OnBeginDrag(PointerEventData data){
		Vector3 screenMousePos = Input.mousePosition;
		Vector3 worldSpaceMousePos = Camera.main.ScreenToWorldPoint (screenMousePos);
		Vector3 canvasMousePos = transform.parent.InverseTransformPoint (worldSpaceMousePos);

		offset = canvasMousePos - transform.localPosition;
	}

	public override void OnDrag(PointerEventData data){
		//get mouse position in canvas
		Vector3 screenMousePos = Input.mousePosition;
		Vector3 worldSpaceMousePos = Camera.main.ScreenToWorldPoint (screenMousePos);
		Vector3 canvasMousePos = transform.parent.InverseTransformPoint (worldSpaceMousePos);

		//image position without clamp
		Vector3 imagePos = canvasMousePos - offset;

		//clamp image to a zone
		float clampedImagePosX = Mathf.Clamp (imagePos.x, -220f, 220f);
		float clampedImagePosY = Mathf.Clamp (imagePos.y, -220f, 220f);

		//move the image
		transform.localPosition = new Vector3 (clampedImagePosX, clampedImagePosY, transform.localPosition.z);
	}
}
