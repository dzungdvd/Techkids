flock = [5, 7, 300, 90, 24, 50, 75]
time_passed = 4
price = 2

print("Hello, my name is Dung and here's my sheep size: ")
print(flock)
print()

for j in range(time_passed):
    
    #flock one month grow
    for i in range(len(flock)):
        flock[i] = flock[i] + 50
    print("MONTH ", j+1)
    print("One month has passed. The flock current sizes: ")
    print(flock)
    
    #shear biggest sheep
    max = 0
    for i in range(len(flock)):
        if max < flock[i]:
            max = flock[i]
    print("Shearing the biggest sheep, which is of size", max)
    flock[flock.index(max)]=8
    print("The flock after shearing: ")
    print(flock)
    print()

sum = 0
for i in range(len(flock)):
    sum = sum + flock[i]
print("My flock size in total: ", sum)
print("The whole flock is worth: $", sum*price)

input("Press Enter to continue...")
