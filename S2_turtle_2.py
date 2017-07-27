from turtle import *

speed(-1)

length = 100

for side_n in range (3,10,1):
    for i in range(side_n):
        if side_n % 2 == 1:
            color("blue")
        else:
            color("red")
        forward(length)
        left(360/side_n)
