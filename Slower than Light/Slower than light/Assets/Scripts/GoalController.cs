using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

	public bool levelComplete;
	public int subGoalComplete;
	public int subGoalTotal;

	GameObject[] subgoals;

	void Start(){
		levelComplete = false;
		subGoalComplete = 0;
		subgoals = GameObject.FindGameObjectsWithTag ("subGoal");
		subGoalTotal = subgoals.Length;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			levelComplete = true;
			foreach (GameObject subgoal in subgoals)
			{
				if (subgoal.GetComponent<SubgoalController> ().complete == true)
					subGoalComplete += 1;
			}
		}
	}
}