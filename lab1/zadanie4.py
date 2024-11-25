import pandas as pd
def algorytmPlecakowyDynamicznePodejście(weights,values,knapsacWeigt,numberOfThings):
    rows, cols = (numberOfThings+1, knapsacWeigt+1)
    arr = [[0 for i in range(cols)] for j in range(rows)]
    listaPrzed=[]
# mamy takie nulowe wiersz o kolumnę, by można było dalej obliczać przypadki, gdy będziemy potrzebowały "rzecz nulową" oraz "pojemnoś plecaka nulową"
    for i in range(1,numberOfThings+1): # dla wszytkich rzeczy w plecaku, zaczynajac od 1
        for j in range(1,knapsacWeigt+1): # dla każdej pojemności plecaka, zaczynając od 1
            if(weights[i-1]==j): # jeżeli waga rzeczy jest taka sama, jak pojemność plecaka
                arr[i][j]=max(values[i-1],arr[i-1][j]) # maksymalne z wartości danej rzeczy oraz wartości poprzednich rzeczy, które znajdują się w plecaku danej pojemności
            elif(weights[i-1]<j):# jeżeli waga rzeczy jest mniejsza od wagi pcaka
                arr[i][j]=max(values[i-1]+arr[i-1][j-weights[i-1]],arr[i-1][j])# max z wartości danej rzeczy+wartości rzeczy, która uzupelnia wagę do potrzebnej (czyli, jeżeli waga 5, waga rzeczy jest 3, to rzecz poszukiwana posiada wagę 2), i wartości poprzednich rzeczy, które odpowiadają pojemości danego plecaka
            else: # no i "wszystkie inne", gdy waga rzeczy jest większa od wagi plecaka
                arr[i][j]=arr[i-1][j] #po prostu wartości poprzednich rzeczy, które znajdują się w plecaku danej pojemności
    DisplayInTable(arr)
    print(f"Maksymalna wartość, która się zmieści w plecaku - {arr[rows-1][cols-1]}")
    return arr

def ShowFinalItemsInKnapsak(arr,rows,cols):
    items=[]
    i=rows
    j=cols


    while(i>0 or j>0): #dopóki nie pierwszy element masywu
        while (arr[i][j] == arr[i - 1][j] and(i>0 or j>0)):#zaczynamy od końca masywu. Porównujemy dany element z elementem o 1 wyżej. Jeżeli jednakowe, kontynujemy porównywać.Jeżeli różne, to dodajemy numer wierszu do listy rzeczy
            i = i - 1
        else:
            items.append(i)
            i = i - 1

            while (arr[i][j] == arr[i][j-1] and (i>0 or j>0)): #porównujemy dany element z elementem po lewej strony.Jeżeli są równe, porównujemy dalej, jeżeli różne - zatrzymujemy na pierwszym się różniącym oraz przechodzimy do porównywania c poprzedniego kroku
                j = j - 1
            else:
                j = j - 1

    return items #lista rzeczy


def algorytmPlecakowyFunkcyjnePodejście(weights,values,volume,numberOfThings):
    print("Proces rekursji:")
    print(f"algorytmPlecakowyFunkcyjnePodejście({volume},{numberOfThings})")
    if numberOfThings == 0 or volume == 0: #jeżeli ilosc przedmiotów czy miejsce w placaku się skończy, zwrócić zero
        return 0
    elif weights[numberOfThings - 1] > volume: # jeżeli rzecz waży więcej niż teraz jest miejsca w plecaku
        return algorytmPlecakowyFunkcyjnePodejście(weights,values,volume, numberOfThings - 1) # następna rzecz
    else:
        brac = values[numberOfThings - 1] + algorytmPlecakowyFunkcyjnePodejście(weights,values,volume - weights[numberOfThings - 1],
                                                                                numberOfThings - 1) # wartosc z rzeczą w plecaku
        nieBrac = algorytmPlecakowyFunkcyjnePodejście(weights,values,volume, numberOfThings - 1)#wartosc bez tej rzeczy
        return max(brac, nieBrac)#wybrać, czy wygodniej jest wziąć czy nie wziąć rzecz

def DisplayInTable(arr):
    myData = {"Pojemności plecaka": arr}
    print(pd.DataFrame(myData))

w=[3,4,1,2] #wagi przedniotów
v=[300,400,350,250] #wartości przedmiotów
W=7
n=4

print("Podejście proceduralne:")
a=algorytmPlecakowyDynamicznePodejście(w,v,W, n)
lista=ShowFinalItemsInKnapsak(a,n,W)
print("Plecak zawiera takie rzeczy:")
for j in lista:
    print(f"{j} rzecz z listy, która waży {w[j-1]}kg i kosztuje {v[j-1]}zl")

print("Podejście funkcyjne:")
print(f"Maksymalna wartość, która się zmieści w plecaku -{algorytmPlecakowyFunkcyjnePodejście(w,v,W,n)}")



