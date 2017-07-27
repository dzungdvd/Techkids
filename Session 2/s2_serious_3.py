column = 20
row = 20

for i in range(column):
    print("* ", end="")

print()
print()

for i in range(int(column/2)):
    print("x ", end="")
    print("* ", end="")

print()
print()

for i in range(int(row)):
    if row % 2 == 0:
        for j in range(int(column/2)):
            print("x ", end="")
            print("* ", end="")
        print()
    else:
        for j in range(int(column/2)):
            print("* ", end="")
            print("x ", end="")
        print()

