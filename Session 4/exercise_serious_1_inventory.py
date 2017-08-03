inventory = {
    'gold' : 500,
    'pouch' : ['flint', 'twine', 'gemstone'],
    'backpack' : ['xylophone', 'dagger', 'bedroll', 'bread loaf']
    }
print("Inventory :")
print(inventory)
print()

inventory["pocket"] = ["seashell", "strange berry", "lint"]
print("Pocket: ")
print(inventory["pocket"])
print()

inventory["backpack"].sort()
print("Backpack: ")
print(inventory["backpack"])
print()

del inventory["backpack"][inventory["backpack"].index('dagger')]
print("Backpack: ")
print(inventory["backpack"])
print()

inventory["gold"] += 50
print("Gold: ")
print(inventory["gold"])
print()

input()
