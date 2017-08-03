def add_fruit(inventory, fruit, quantity=0):
    if fruit in inventory:
        inventory[fruit] += quantity
    else:
        inventory[fruit] = quantity
    return

def test(test_value):
    print(test_value)
    return

# Make these tests work...
new_inventory = {}

add_fruit(new_inventory, "strawberries", 10)
print(new_inventory)
test("strawberries" in new_inventory)
test(new_inventory["strawberries"] == 10)
add_fruit(new_inventory, "strawberries", 25)
print(new_inventory)
test(new_inventory["strawberries"] == 35)

input("Press Enter to continue...")

##(a) 	>>> d = {"apples": 15, "bananas": 35, "grapes": 12}
##	>>> d["bananas"]
##Answer: 35. It is the value of the “bananas” key.
##
##(b)	 >>> d["oranges"] = 20
##	>>> len(d)
##Answer: 4. It is the length of the dictionary.
##
##(c) 	>>> "grapes" in d
##Answer: True. There is a key named “grapes” in the dictionary.
##
##(d) 	>>> d["pears"]
##Answer: Error. There is no key named “pears” in the dictionary.
##
##(e) 	>>> d.get("pears", 0)
##Answer: 0. There is no key named “pears” in the dictionary, so the alternative value of 0 is used.
##
##(f) 	>>> fruits = list(d.keys())
##	>>> fruits.sort()
##	>>> print(fruits)
##Answer: ['apples', 'bananas', 'grapes', 'oranges']. An arranged list of the dictionary keys
##
##(g) 	>>> del d["apples"]
##	>>> "apples" in d
##Answer: False. The “apples” key is no longer in the dictionary.
