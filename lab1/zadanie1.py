#zadanie 1
def podziel(wagi, max_waga):

    kursy =[]
    wagi_sorted= sorted(wagi, reverse=True)
    for i in wagi_sorted:
        if(i>max_waga):
            raise ValueError(f"Paczka o wadze waga przekraca dozwoloną wagę kursu{max_waga}.")
        dodana = False
        for kurs in kursy:
            if sum(kurs)+i<=max_waga:
                kurs.append(i)
                dodana=True
                break
        if not dodana:
            kursy.append([i])


    return len(kursy),kursy

wagi = [10, 15, 25, 8, 7, 5]
max_waga=25
podziel(wagi,max_waga)
liczba_kursow, kursy = podziel(wagi,max_waga)
print(f"Liczba kursów:{liczba_kursow}")
for i, kurs in  enumerate (kursy,1):
    print(f"Kurs {i}:{kurs} - suma wag: {sum(kurs)} kg")