while(True):
    i_string = input("Please input a sentence: ")
    i_string = i_string.lower()

    #counting letters
    letter_counts = {}
    for letter in i_string:
        letter_counts[letter] = letter_counts.get(letter, 0) + 1

    #sorting letters
    letter_list = list(letter_counts.items())
    letter_list.sort()

    #displaying the list, ignoring non-alpha numeric characters
    for letter in range(len(letter_list)):
        if letter_list[letter][0].isalnum():
            print(letter_list[letter][0], letter_list[letter][1])
    print()
