using System;

namespace Session2inC
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//BMI EXERCISE
			Console.Write ("What's your height in cm? ");
			float height = float.Parse (Console.ReadLine ()) / 100;
			Console.Write ("What's your weight in kg? ");
			float weight = float.Parse (Console.ReadLine ());
			float bmi = weight / (height * height);
			Console.WriteLine ("Your BMI is: " + bmi.ToString ("0.00"));
			if (bmi < 16) {
				Console.WriteLine ("You're severely underweight. You should put some meat on your bones.");
			} else if (bmi <= 18.5) {
				Console.WriteLine ("You're underweight. Go eat something.");
			} else if (bmi <= 25) {
				Console.WriteLine ("You're of normal weight. Cheers!");
			} else if (bmi <= 30) {
				Console.WriteLine ("You're overweight. Get some salads.");
			} else if (bmi > 30) {
				Console.WriteLine ("You're obese. You should get some exercises and a balanced meal plan.");
			} else {
				Console.WriteLine ("Something has gone terribly wrong with the program :(");
			}
			Console.ReadLine ();

			//BMAX EXERCISE
			Console.WriteLine ();
			Console.WriteLine ();
			Console.Write ("Hello, ");
			Console.Write ("my name is ");
			Console.WriteLine ("B-Max!");

			Console.WriteLine ();
			Console.WriteLine ();
			int column = 20;
			int row = 20;

			//STARS EXERCISE
			for (int i = 0; i < column; i++) {
				Console.Write ("* ");
			}

			Console.WriteLine ();
			Console.WriteLine ();
			for (int i = 0; i < column / 2; i++) {
				Console.Write ("x ");
				Console.Write ("* ");
			}

			Console.WriteLine ();
			Console.WriteLine ();
			for (int i = 0; i < row; i++) {
				if (i % 2 == 0) {
					for (int j = 0; j < column / 2; j++) {
						Console.Write ("x ");
						Console.Write ("* ");
					}
				} else {
					for (int j = 0; j < column / 2; j++) {
						Console.Write ("* ");
						Console.Write ("x ");
					}	
				}
				Console.WriteLine ();
			}
			Console.ReadLine ();
		}
	}
}
