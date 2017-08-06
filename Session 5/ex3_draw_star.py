from turtle import *
speed(-1)

def draw_star(x, y, length):
    penup()
    setpos(x, y)
    pendown()
    for i in range(5):
        forward(length)
        right(144)
    
draw_star(-100, -100, 200)

input()
