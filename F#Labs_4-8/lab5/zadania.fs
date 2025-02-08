
    let sumIter n = 
        let mutable sum = 0
        for i in 1..n do
            sum <- sum + 1
        sum

    let result = sumIter 8
    printf "Suma iter: %d\n" result


    let rec sumRek n =
        if n <= 0 then 0
        else n + sumRek (n-1)

    let result1 = sumRek 8
    printf "Suma rek: %d\n" result1


    let rec sumaRekOgon n acc =
        if n <= 0 then acc
        else sumaRekOgon (n-1) (acc + n)

    let result2 = sumaRekOgon 8 0
    printf "Suma rek ogonowa: %d\n" result2


    let rec silniaOgon n acc =
        if n <=1 then acc
        else silniaOgon (n-1) (n * acc)

    let result3 = silniaOgon 5 1
    printf "5! = %d\n" result3


    let rec fibRec n =
        if n <= 0 then 0
        elif n = 1 then 1
        else fibRec (n-1) + fibRec (n-2)

    let result4 = fibRec 5
    printf "Fibbonaci rec: %d \n" result4
    
    let rec fibRecTail n a b =
        if n <= 0 then a
        elif n = 1 then b
        else fibRecTail (n - 1) b (a + b)

    let result5 = fibRecTail 5 0 1
    printf "Fibbonaci rec ogon: %d \n" result5
    
    let rec hanoiFunc n fromR toR auxR =
        if n = 1 then
            printfn "Przenieś element z %A na %A" fromR toR
        else
            hanoiFunc (n - 1) fromR auxR toR
            printfn "Przenieś elemnt z %A na %A" fromR toR
            hanoiFunc (n - 1) auxR toR fromR

    printf "Hanoi: "
    hanoiFunc 3 "B" "C" "A"

    let rec quickSort lista =
        match lista with
        | [] -> []
        | pivot :: tail ->
            let left = List.filter (fun x -> x < pivot) tail
            let right = List.filter (fun x -> x >= pivot) tail
            quickSort left @ [pivot] @ quickSort right

    let list1 = [9; 3; 1]
    let list2 = [5; 7; 4]
    let result6 = quickSort (list1 @ list2) 
    printf "QuickSort: %A \n" result6

