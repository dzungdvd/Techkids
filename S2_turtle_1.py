from turtle import *

speed(-1)
color("red")
pensize(7)

angle = 60
length = 100

for i in range(4):
    left(angle/2)
    forward(length)
    right(angle)
    forward(length)
    right(180-angle)
    forward(length)
    right(angle)
    forward(length)
    left(angle/2)
    left(90)
