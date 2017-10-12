using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static GameController Instance { get; private set;}

	public GameObject player;
	public Camera camera;
	public GameObject gameOverUI;

	private SpriteRenderer sr;
	private Controller2D controller2d;
	private PlatformSpawner platformSpawner;

	public bool playerAlive = true;
	private Vector2 playerStartPos;
	private Vector3 cameraStartPos;

	void Awake(){
		Instance = this;
	}

	void Start () {
		sr = player.GetComponent<SpriteRenderer> ();
		controller2d = player.GetComponent<Controller2D> ();
		platformSpawner = gameObject.GetComponent<PlatformSpawner> ();
		playerStartPos = player.transform.position;
		cameraStartPos = camera.transform.position;
		gameOverUI.SetActive (false);
		platformSpawner.SpawnInitialPlatforms ();
	}
	
	public void OnPlayerDeath(){
		gameOverUI.SetActive (true);
		sr.enabled = false;
		playerAlive = false;
	}

	public void NewGame(){
		gameOverUI.SetActive (false);
		sr.enabled = true;
		playerAlive = true;
		player.transform.position = playerStartPos;
		camera.transform.position = cameraStartPos;
		platformSpawner.DeactiveAllPlatforms ();
		platformSpawner.SpawnInitialPlatforms ();
	}
}
