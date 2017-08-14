using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGame : MonoBehaviour {

	string helloString;

	//Use this for initialization
	void Start () {
		List<int> numbers = new List<int>();
		for (int i = 0; i < 10; i++) {
			numbers.Add(Random.Range(0,100));
		}

		int max = -2147483648;
		for (int i = 0; i < numbers.Count; i++) {
			print (numbers [i]);
			if (numbers[i] > max) {
				max = numbers[i];
			}
		}
		print ("Max = " + max);


		
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
