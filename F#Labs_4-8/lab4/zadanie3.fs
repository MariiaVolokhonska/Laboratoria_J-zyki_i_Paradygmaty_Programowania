open System
open System.Collections.Generic

let countWords (text: string) =
    text.Split([|' '; '\t'; '\n'; '\r'|], StringSplitOptions.RemoveEmptyEntries)
    |> Array.length

let countCharacters (text: string) =
    text |> Seq.filter (fun c -> not (Char.IsWhiteSpace c)) |> Seq.length

let mostFrequentWord (text: string) =
    text.Split([|' '; '\t'; '\n'; '\r'|], StringSplitOptions.RemoveEmptyEntries)
    |> Array.countBy id
    |> Array.sortByDescending snd
    |> Array.tryHead
    |> function
        | Some (word, _) -> word
        | None -> "Brak danych"

[<EntryPoint>]
let main argv =
    printf "Wprowadź tekst: "
    let input = Console.ReadLine()
    
    let wordCount = countWords input
    let charCount = countCharacters input
    let frequentWord = mostFrequentWord input
    
    printfn "Liczba słów: %d" wordCount
    printfn "Liczba znaków (bez spacji): %d" charCount
    printfn "Najczęściej występujące słowo: %s" frequentWord
    
    0
    