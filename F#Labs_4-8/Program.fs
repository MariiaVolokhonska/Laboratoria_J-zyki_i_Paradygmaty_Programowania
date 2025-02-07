
let exchangeRates =
    Map [
        ("USD", "EUR"), 0.97
        ("USD", "GBP"), 0.81
        ("EUR", "USD"), 1.0 / 0.97
        ("EUR", "GBP"), 0.83
        ("GBP", "USD"), 1.0 / 0.81
        ("GBP", "EUR"), 1.0 / 0.83
    ]

let convertCurrency amount fromCurrency toCurrency=
    match exchangeRates.TryFind(fromCurrency, toCurrency) with
    | Some rate -> amount * rate
    | None ->
        printfn "Nie można konwertować walute."
        0.0


let rec readFloat prompt =
    printfn "%s" prompt
    match System.Double.TryParse(System.Console.ReadLine()) with
    | (true, value) -> value
    |_ -> 
        printfn "Bledne dane. Uzyj popranych danych typu numerycznego"
        readFloat prompt
let rec readString prompt =
    printfn "%s" prompt
    match System.Console.ReadLine() with
    | "GPB"-> "GPB"
    | "EUR"-> "EUR"
    | "USD"-> "USD"
    |_ -> 
        printfn "Bledne dane. Uzyj popranych danych : USD, EUR, GBP"
        readString prompt
let main() =
    let currentCurrency = readString "Wprowadz walutę początkową (USD, EUR, GBP)"
    let expectedCurrency=readString "Wprowadz walute docelową (USD, EUR, GBP)"
    let amountOfMoney = readFloat "Wprowadz kwotę którą trzeba przekonwertować"

   

    let result = convertCurrency amountOfMoney currentCurrency expectedCurrency
    printfn "Przeliczona kwota: %.2f %s" result expectedCurrency

main()