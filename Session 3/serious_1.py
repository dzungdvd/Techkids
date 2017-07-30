stock = ["T-Shirt", "Sweater"]

while(True):
    print()
    command = input("Welcome to our shop, what do you want (C, R, U, D)?")

    if command.upper() == "C":
        item = input("Enter new item: ")
        stock.append(item)
        print("List of items currently in stock: ", end="")
        print(stock)
        
    elif command.upper() == "R":
        print("List of items currently in stock: ", end="")
        print(stock)
        
    elif command.upper() == "U":
        while(True):
            position = int(input("Which position do you want to update? ")) - 1
            if 0<=position<=len(stock)-1:
                break
        item = input("Enter new item: ")
        stock[position] = item
        print("List of items currently in stock: ", end="")
        print(stock)
        
    elif command.upper() == "D":
        while(True):
            position = int(input("Which position do you want to delete? ")) - 1
            if 0<=position<=len(stock)-1:
                break
        del stock[position]
        print("List of items currently in stock: ", end="")
        print(stock)
        
    else:
        print("Wrong command.")
        print("Input C to enter a new item.")
        print("Input R to read current stock.")
        print("Input U to update an existing item.")
        print("Input D to delete an existing item.")
    input("Press Enter to continue...")
