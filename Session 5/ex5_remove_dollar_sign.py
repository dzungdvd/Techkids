##Write a function that removes the dollar sign (“$”) in a string,
##named remove_dollar_sign, takes 1 parameter: s,
##where s is the input string, returns the new string with no dollar sign in it
##Hint: Google “Python string replace remove”

def remove_dollar_sign(s):
    return s.replace("$", "")

test = "I love $_$"
print(test)
print(remove_dollar_sign(test))
input()
