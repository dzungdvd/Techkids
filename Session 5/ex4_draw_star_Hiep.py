from turtle import *
speed(-1)

def draw_star(x, y, length):
    penup()
    setpos(x, y)
    pendown()
    for i in range(5):
        forward(length)
        right(144)

print("random.randint(a, b) is a function that returns a random integer between a & b (a <= x <= b).")
print("In this case it is used to generate a random location and length of the next star")
    
speed(0)
color('blue')
for i in range(100):
    import random
    x = random.randint(-300, 300)
    y = random.randint(-300, 300)
    length = random.randint(3, 10)
    draw_star(x, y, length)

input()
