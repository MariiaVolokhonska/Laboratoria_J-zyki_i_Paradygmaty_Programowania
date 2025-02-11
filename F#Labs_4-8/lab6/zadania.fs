open System

// Zadanie 1
let liczbaSlowIZnakow (tekst: string) =
    let slowa = tekst.Split([|' '; '\t'; '\n'|], StringSplitOptions.RemoveEmptyEntries)
    let liczbaSlow = slowa.Length
    let liczbaZnakow = tekst.Replace(" ", "").Length
    printfn "Liczba słów: %d" liczbaSlow
    printfn "Liczba znaków (bez spacji): %d" liczbaZnakow

printf "Podaj tekst: "
let tekst = Console.ReadLine()
liczbaSlowIZnakow tekst

// Zadanie 2
let czyPalindrom (tekst: string) =
    let oczyszczony = tekst.ToLower().Replace(" ", "")
    oczyszczony = new string(Array.rev (oczyszczony.ToCharArray()))

printf "Podaj tekst: "
let tekst2 = Console.ReadLine()
if czyPalindrom tekst2 then printfn "To jest palindrom" else printfn "To nie jest palindrom"

// Zadanie 3
let usunDuplikaty (lista: string list) =
    lista |> List.distinct

printf "Podaj słowa oddzielone spacjami: "
let wejscie = Console.ReadLine()
let slowa = wejscie.Split([|' '|], StringSplitOptions.RemoveEmptyEntries) |> Array.toList
let unikalne = usunDuplikaty slowa
printfn "Unikalne słowa: %A" unikalne

// Zadanie 4
let przeksztalcFormat (linia: string) =
    let dane = linia.Split(';')
    if dane.Length = 3 then
        sprintf "%s, %s (%s lat)" dane.[1] dane.[0] dane.[2]
    else
        "Błędny format"

printf "Podaj wpisy w formacie 'imię;nazwisko;wiek': "
let wejscie4 = Console.ReadLine()
let wpisy = wejscie4.Split([|','|], StringSplitOptions.RemoveEmptyEntries) |> Array.toList
wpisy |> List.map przeksztalcFormat |> List.iter (printfn "%s")

// Zadanie 5
let znajdzNajdluzszeSlowo (tekst: string) =
    let slowa = tekst.Split([|' '; '\t'; '\n'|], StringSplitOptions.RemoveEmptyEntries)
    if slowa.Length > 0 then
        let najdluzsze = slowa |> Array.maxBy (fun s -> s.Length)
        (najdluzsze, najdluzsze.Length)
    else
        ("", 0)

printf "Podaj tekst: "
let tekst5 = Console.ReadLine()
let (slowo, dlugosc) = znajdzNajdluzszeSlowo tekst5
printfn "Najdłuższe słowo: %s, Długość: %d" slowo dlugosc

// Zadanie 6
let zamienSlowo (tekst: string) (szukane: string) (zamiana: string) =
    tekst.Replace(szukane, zamiana)

printf "Podaj tekst: "
let tekst6 = Console.ReadLine()
printf "Podaj słowo do zamiany: "
let szukane = Console.ReadLine()
printf "Podaj słowo, które zamieni: "
let zamiana = Console.ReadLine()
let nowyTekst = zamienSlowo tekst6 szukane zamiana
printfn "Zmodyfikowany tekst: %s" nowyTekst
