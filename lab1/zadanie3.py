N = 5# ilośc zadań
dictCzasWartoscMinuta = {}
zadania = [[12, 2000], [10, 300], [5, 200], [14, 3000], [45, 15000]]


# 1 - sposób proceduralny
# myśłę tak, że to zadanie można rozwiązać na podstawie tego, ile pieniędzy można otrzymać na minutę za wykonywanie zadania
def bubbleSortDict(d):
    lis = list(d.items())
    l = len(lis)
    for i in range(l):
        for j in range(0, l - i - 1):
            if lis[j][1] < lis[j + 1][1]:
                lis[j], lis[j + 1] = lis[j + 1], lis[j]
    return dict(lis)

def MaxWygodaProceduralnie(zadania, dictCzasWartoscMinuta):
    for i in range(N):
        dictCzasWartoscMinuta[zadania[i][0]] = (zadania[i][1] / zadania[i][0])

    return bubbleSortDict(dictCzasWartoscMinuta)

sortedDict=MaxWygodaProceduralnie(zadania,dictCzasWartoscMinuta)

def printOutput(diction, paradigm):
    print(
        f"Najwygodniejsza kolejność zadań z punktu widzenia minimalnego oczekiwania oraz maksymalnego zysku jest taka({paradigm}):")
    j = 1
    for key, value in diction.items():
        print(f"{j} - {key} minut : {value} zł na minute \n")
        j = j + 1

printOutput(sortedDict,"proceduralnie")

#2 - sposób funkcyjny
def MaxWygodaFunkcyjnie(zadania):
    wartoscNaMin = list(map(lambda i: i[1]/i[0], zadania))
    listaMinut = list(map(lambda j: j[0], zadania))
    dictionary = dict(zip(listaMinut, wartoscNaMin))

    return dict(sorted(dictionary.items(), key=lambda item: item[1], reverse=True))


printOutput(MaxWygodaFunkcyjnie(zadania),"funkcyjnie")
