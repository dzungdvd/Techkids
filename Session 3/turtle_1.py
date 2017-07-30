from turtle import *

speed(-1)
length = 100
colors = ['red', 'blue', 'brown', 'yellow', 'grey']

for side_n in range (3,8,1):
    for i in range(side_n):
        color(colors[side_n - 3])
        forward(length)
        left(360/side_n)
