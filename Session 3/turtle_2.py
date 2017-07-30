from turtle import *

speed(-1)
width = 50
height = 100
colors = ['red', 'blue', 'brown', 'yellow', 'grey']

for i in range(len(colors)):
    
    color(colors[i])
    begin_fill()
    forward(width)
    right(90)
    forward(height)
    right(90)
    forward(width)
    right(90)
    forward(height)
    right(90)
    forward(width)
    end_fill()

