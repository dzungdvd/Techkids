height = float(input("What's your height in cm? "))/100
weight = float(input("What's your weight in kg? "))
bmi = weight / height**2

print("Your BMI is: ", round(bmi,1), ". ", end="")
if bmi < 16:
    print("You're severely underweight. You should put some meat on your bones.")
elif bmi <= 18.5:
    print("You're underweight. Go eat something.")
elif bmi <= 25:
    print("You're of normal weight. Cheers!")
elif bmi <= 30:
    print("You're overweight. Get some salads.")
elif bmi > 30:
    print("You're obese. You should get some exercises and a balanced meal plan.")
