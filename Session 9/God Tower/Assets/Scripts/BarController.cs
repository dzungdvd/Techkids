using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour {

	public Image barImage;

	// Use this for initialization
	void Start () {
		barImage = GetComponent<Image> ();
	}

	public void OnPointerEnter()
	{
		Color tempColor = barImage.color;
		tempColor.a = 0;
		barImage.color = tempColor;
	}

	public void OnPointerExit()
	{
		Color tempColor = barImage.color;
		tempColor.a = 1;
		barImage.color = tempColor;
	}

}
