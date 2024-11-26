
from collections import Counter
print("1 - Tasks from first part of first task")
#1 - zlicznie liczby slow, zdan i akapitow
text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer ac posuere eros. Ut efficitur feugiat diam. Mauris quis magna vitae diam aliquet facilisis. Aenean vestibulum mi nec mauris pharetra aliquet. Fusce et lacus turpis. Vestibulum gravida erat sit amet magna accumsan, sit amet faucibus dolor pharetra. Integer tristique cursus euismod. Aenean convallis lorem eleifend mauris volutpat lobortis.\nQuisque consequat pharetra massa sed euismod. Ut fringilla neque sit amet vulputate fermentum. Praesent lobortis, dolor quis gravida hendrerit, nisl turpis eleifend quam, a ornare leo orci at sem. Curabitur tortor urna, tristique at tincidunt quis, consectetur in quam. Quisque mattis, diam et dapibus sodales, enim felis molestie justo, tincidunt mollis mauris massa tincidunt urna. Donec malesuada neque eget posuere scelerisque. Morbi eget tellus lacinia, facilisis quam ut, egestas tortor.\nDonec et ornare ipsum. Ut sodales semper dui, eget euismod purus faucibus eget. Nulla facilisi. Maecenas consequat magna ac augue varius, ac consectetur erat porta. Donec commodo id nisi ac ultrices. Nunc tincidunt, elit id feugiat scelerisque, diam sem elementum risus, quis rhoncus neque massa sed purus. Nam nec cursus mi, ac varius urna. Duis varius tincidunt leo ac varius. Proin aliquet egestas augue et dictum. Donec lacinia metus elementum suscipit vestibulum. Sed eu nulla vitae neque bibendum rutrum vitae a augue. Quisque quis est aliquet, ornare ipsum eu, accumsan mi. In vehicula, arcu a maximus pretium, lacus tellus lobortis neque, ac laoreet tortor massa quis lectus."
print("Liczba zdań")
print(text.count('.'))
print("Liczba akapitów")
print(text.count('\n'))
print("Liczba słów")
text1=text.replace('\n',' ') #zamieniamy akapit na spacje by policzyć slowa
print(text1.count(' ')+1) #każda kropka oraz każdy przycinek jest "przywiązany do slowa".Po każdym slowie stoi spacja. To oznacza, że ilośc słów będzie ilość spacji+ ostatnie slowo w tekście
def TransformSentance(story):
    text2 = story.replace(',', '').replace('.', '')
    listOfWords = text2.split(' ')
    return listOfWords
#2 - Wyszukuje najczęściej występujące słowa, wykluczając tzw. stop words (np. "i", "a", "the").
def FindMostFrequentWord(story):
    stopWords = ['and', 'a', 'the', 'and', 'but', 'or', 'in', 'on', 'at', 'with', 'am', 'is', 'are', 'was', 'were', 'being',
                 'be','he','she','it','you','I','not','My','her','his','your','too']
    listOfWords=TransformSentance(story)
    listWithoutStops = list(filter(lambda x: x not in stopWords, listOfWords))
    counter = Counter(listWithoutStops)
    maximum=0
    word=''
    for i in counter:
        if(maximum<counter[i]):
            maximum=counter[i]
            word=i


    print(f"2 - The most frequent word in text is \"{word}\"")

story="Hi. My name is Mariia. I really love programming. Also I love reading, writing. My favourite sport is chess. Yes, it is sport. No, I am not joking. Speaking about favourite writer, his middle name is Mariia too. My dog name is Ostin"
FindMostFrequentWord(story)

#3 - Transformuje wszystkie wyrazy rozpoczynające się na literę "a" lub "A" do ich odwrotności
def ReverseWords(story):
    listOfWords = TransformSentance(story)
    lista=list(map(lambda x: x[::-1],filter(lambda y: y[0]=='a' or y[0]=='A',listOfWords)))
    print(lista)
print("3 - Reversed words that starts with \"A\" or \"a\"")
ReverseWords(story)