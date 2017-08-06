##Write a Python function that draws a square, named draw_square,
##takes 2 input parameters: length and color, where length is
##the length of its side and color is the color of its bound (line color)

from turtle import *
speed(-1)

def draw_square(length, color):
    pencolor(color)
    forward(length)
    right(90)
    forward(length)
    right(90)
    forward(length)
    right(90)
    forward(length)
    right(90)

draw_square(100, "red")

input()
