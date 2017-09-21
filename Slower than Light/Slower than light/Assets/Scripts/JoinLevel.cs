using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinLevel : MonoBehaviour {
	public int level;


	public void levelButton () {
		
		SceneManager.LoadScene ("Level " + level.ToString());

	}
}
