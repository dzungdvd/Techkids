prices = {"banana" : 4,
          "apple" : 2,
          "orange" : 1.5,
          "pear" : 3}

purchased_items_dict = {"banana" : 5,
                        "orange" : 3}
purchased_items = list(purchased_items_dict.items())

total = 0
for purch_item in purchased_items:
    print("{0}, quantity: {1}, unit price: {2}".format(purch_item[0],
                                                       purch_item[1],
                                                       prices[purch_item[0]]))
    sub_total = purch_item[1] * prices[purch_item[0]]
    print("Sub total: ", sub_total)
    print()
    total += sub_total
print("*********************")
print("Total: ", total)

input()


