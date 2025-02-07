type User = {Weight: float; Height: float}

//Obliczenie BMI
//Waga(kg)^2/wzrost(m)

let calculateBMI user =
    let heightmetres = user.Height/100.0
    user.Weight / (heightmetres ** 2.0)


let categoryBMI bmi=
    if bmi <18.5 then "Niedowaga"
    elif bmi <24.9 then "Waga Prawidłowa"
    elif bmi <29.9 then "Nadwaga"
    else "Otylosc"


let rec readFloat prompt =
    printfn "%s" prompt
    match System.Double.TryParse(System.Console.ReadLine()) with
    | (true, value) -> value
    |_ -> 
        printfn "Bledne dane. Uzyj popranych danych typu numerycznego"
        readFloat prompt


let main() =
    let weight  = readFloat "Podaj swoja wage w kg: "
    let height = readFloat "Podaj swoj wzrost w cm "


    let user = { Weight = weight; Height = height}

    let bmi = calculateBMI user

    printfn "Twoje BMI wynosi: %.2f" bmi
    printfn "Twoja kategoria BMU %s" (categoryBMI bmi)

main()