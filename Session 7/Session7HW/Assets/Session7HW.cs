using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session7HW : MonoBehaviour
{
	//		1. Viết 1 chương trình convert 1 list có N phần tử (không cần nhập vào từ bàn phím) số hệ thập phân ra hệ nhị phân nhé, mấy cái 10001011 ý :)))
	//		2. Viết 1 chương trình tìm ra ước số chung lớn nhất của 1 list có N phần tử (không cần nhập vào từ bàn phím) số nhé.

	void Start ()
	{
		//create a random list
		int n = 10;
		List<int> rngList = new List<int> ();
		for (int i = 0; i < n; i++) {
			rngList.Add (Random.Range (0, 9999));
			print (rngList [i]);
		}

		//convert list to binary
		List<string> binaryList = new List<string> ();
		for (int i = 0; i < n; i++) {
			binaryList.Add(ToBinary (rngList [i]));
			print (binaryList[i]);
		}

		//find a list greatest common divisor
		int gcd = 1;
		for (int i = 0; i < n; i++) {
			for (int j = i+1; j < n; j++) {
				if (EuclideanAlgorithm (rngList [i], rngList [j]) > gcd) {
					gcd = EuclideanAlgorithm (rngList [i], rngList [j]);
				}
			}
		}
		print ("The greatest common divisor of the list is: " + gcd);
	}

	//convert an integer to binary in string
	public string ToBinary (int inputNumber)
	{
		return System.Convert.ToString (inputNumber, 2);
	}

	//find greatest common divisor of two numbers
	public int EuclideanAlgorithm(int a, int b)
	{
		while (a != b) {
			if (a > b) {
				a = a - b;
			} else {
				b = b - a;
			}
		}
		return a;
	}
}
