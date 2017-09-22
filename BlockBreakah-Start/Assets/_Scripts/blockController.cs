using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour {

	GameController gm;
	SpriteRenderer sr;
	public float colorChange;
	public int life;

	void Start()
	{
		gm = GameObject.Find ("GameController").GetComponent<GameController>();
		sr = transform.Find ("BlockSprite").GetComponent<SpriteRenderer> ();
		UpdateColor ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			BlockHit ();
		}
	}

	void Update()
	{
		if (life == 0) {
			Destroy (gameObject);
		}
	}

	void BlockHit()
	{
		gm.BlockCountChange (-1);
		life += -1;
		UpdateColor ();
	}

	void UpdateColor(){
		sr.color = new Color (
			0.7f - life*0.2f,
			0.7f - life*0.2f,
			0.7f - life*0.2f);
	}

}
