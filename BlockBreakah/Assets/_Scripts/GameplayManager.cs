using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour {
	public static GameplayManager Instance { get; private set; }

	public string nextLevelName;
	private List<BlockController> allBlocks = new List<BlockController>();
	public List<SpriteRenderer> wallSr;
	private Color originalColor;
	private Coroutine wallFlashCoroutine;

	void Awake() {
		Instance = this;
		originalColor = wallSr [0].color;
	}

	void OnDestroy(){
		StopAllCoroutines ();
	}

	public void OnBallHitBottom(){
		SceneManager.LoadScene ("Gameover");
	}

	public void OnNewBlockCreated(BlockController block){
		allBlocks.Add (block);
	}

	public void OnBlockDestroyed(BlockController block){
		allBlocks.Remove (block);

		if (allBlocks.Count == 0) {
			LevelCompleted ();
		}
	}

	private void LevelCompleted(){
		SceneManager.LoadScene (nextLevelName);
	}

	public void WallFlash(){
		if (wallFlashCoroutine != null) 
			StopCoroutine (wallFlashCoroutine);
		wallFlashCoroutine = StartCoroutine (WallFlashCoroutine ());
	}

	IEnumerator WallFlashCoroutine(){
		Color startColor = Color.HSVToRGB(0f, 0.9f, 0.9f);

		float time = 0;
		while (time < 0.3f) {
			foreach (SpriteRenderer sr in wallSr) {
				sr.color = Color.Lerp (startColor, originalColor, time / 0.3f);
			}
				
			time += Time.deltaTime;
			yield return null;
		}

		foreach (SpriteRenderer sr in wallSr) {
			sr.color = originalColor;
		}
	}
}
