file_input = open("11.txt", "r")
alice = file_input.read()
file_input.close()

word_dict = {}

def add_word_count(dictionary, word):
    if word in dictionary:
        dictionary[word] += 1
    else:
        dictionary[word] = 1
    return

#search for a word, then add it into the dictionary
index = 0
search_for_word_start = True
while index < len(alice):
    if search_for_word_start == True: #search for the start of a word
        if alice[index].isalpha():
            word_start_index = index
            search_for_word_start = False
        else:
            index += 1
    else: #search for the end of a word
        if alice[index].isalpha() == False:
            word_end_index = index
            search_for_word_start = True
            new_word = alice[word_start_index : word_end_index]
            add_word_count(word_dict, new_word.lower())
        else:
            index += 1

#generating a list from dictionary & sort it
words_list = list(word_dict.items())
words_list.sort()

#writing list to file
file_output = open("alice_words.txt", "w")
for word in words_list:
    file_output.write(word[0])
    file_output.write(" ")
    file_output.write(str(word[1]))
    file_output.write("\n")
file_output.close()

print("alice ", word_dict["alice"])
