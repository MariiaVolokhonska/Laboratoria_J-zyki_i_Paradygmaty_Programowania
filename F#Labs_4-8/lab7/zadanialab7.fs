//Zadanie 1

type Book(title: string, author:string, pages:int) =
    member this.Title=title
    member this.Author=author
    member this.Pages=pages

    
    member this.GetInfo() = 
        sprintf "Tytuł: %s, Author: %s, Liczba stron: %d" this.Title this.Author this.Pages
    

type User(name: string) =

    let borrowBooks = System.Collections.Generic.List<Book>()
    member this.Name=name

    member this.BorrowBook(book: Book) =
        borrowBooks.Add(book)
        printfn "%s wypozyczyl/a ksiazke:  \"%s\"" this.Name book.Title

    member this.ReturnBook(book: Book) = 
        if borrowBooks.Contains(book) then
            borrowBooks.Remove(book)
            printf "%s zwrócił/a ksiazke \"%s\"" this.Name book.Title
        else
            printfn "%s nie ma ksiazki do wrócenia \"%s\"" this.Name book.Title

    member this.ListBorrowBooks()=
        if borrowBooks.Count > 0 then 
            borrowBooks
            |> Seq.map(fun book -> book.GetInfo())
            |> String.concat "\n"
            |> printfn "Książki wypozyczone przez %s: \n%s" this.Name
        else
            printfn "%s nie ma wypożyczonych książek" this.Name

type Library() = 
    let mutable books = System.Collections.Generic.List<Book>()

    member this.AddBook(book: Book) = 
        books.Add(book)
        printfn "+ \"%s\"" book.Title

    member this.RemoveBook(book: Book) = 
        if books.Contains(book) then 
            books.Remove(book)
            printfn "Książka \"%s\" została usunięta" book.Title
        else
            printfn "Nie ma podobnej książki"
    
    member this.ListBooks() =
        if books.Count > 0 then 
            books
            |> Seq.map(fun book -> book.GetInfo())
            |> String.concat "\n"
            |> printfn "Książki w bibliotece: \n%s" 
        else
            printfn "W bibliotece nie ma książek"

let main() = 
    let library = Library()
    let user = User("Ala")

    let book1 = Book("Hunger Games", "Suzanne Collins", 250)
    let book2 = Book("Flowers for Algernon", "Daniel Kiz", 147)
    let book3 = Book("After Dark", "Haruki Murakami", 180)

    library.AddBook(book1)
    library.AddBook(book2)
    library.AddBook(book3)

    library.ListBooks()

    user.BorrowBook(book1)
    user.BorrowBook(book2)

    library.ListBooks()
    user.ListBorrowBooks()

    user.ReturnBook(book1)
    user.ListBorrowBooks()
    library.RemoveBook(book1)

main()

//Zadanie 2
type BankAccount(accountNumber: string, Balance: float) =
    let mutable privateBalance = Balance

    member this.AccountNumber = accountNumber
    member this.Balance
        with get() = privateBalance
        and set(value) = 
            if value > 0.0 then 
                privateBalance <- value
            else
                printfn "Balance musi być >0"

    member this.Deposit(amount: float) =
        if amount <= 0.0 then 
            printfn "Kwota wpłaty musi być >0"
        else
            this.Balance <- this.Balance + amount

    member this.Withdraw(amount: float) =
        if amount <= 0.0 then 
            printfn "Kwota wypłaty musi być >0"
        elif amount > this.Balance then
            printfn "Nie wystarcza środków"
        else
            this.Balance <- this.Balance - amount

type Bank() =
    let mutable accounts = System.Collections.Generic.Dictionary<string, BankAccount>()

    member this.CreateAccount(Number: string, Balance: float) = 
        if accounts.ContainsKey(Number) then
            printfn "Konto o numerze \"%s\" już istnieje" Number
        else
            let account = BankAccount(Number, Balance) 
            accounts.Add(Number, account)
            printfn "Konto numer \"%s\" został dodany" account.AccountNumber
            
    member this.GetAccount(Number: string) = 
        if accounts.ContainsKey(Number) then
            Some(accounts.[Number])
        else
            printfn "Konto o numerze \"%s\" nie istnieje" Number
            None

    member this.UpdateAccount(Number: string, NewBalance: float) =
        match this.GetAccount(Number) with
        | Some account -> account.Balance <- NewBalance
        | None -> printfn "Nie można zaktualizować konta: nie istnieje."

    member this.DeleteAccount(Number: string) = 
        if accounts.ContainsKey(Number) then
            accounts.Remove(Number) |> ignore
            printfn "Konto o numerze \"%s\" zostało usunięte" Number
        else
            printfn "Nie ma konta o podanym numerze."

let mainBank() =
    let bank = Bank()
    
    bank.CreateAccount("800000", 45.0)
    bank.CreateAccount("900000", 15.0)
    bank.CreateAccount("1000000", 35.0)

    match bank.GetAccount("800000") with
    | Some konto1 -> konto1.Deposit(700.0)
    | None -> printfn "Nie można wpłacić: konto nie istnieje."

    match bank.GetAccount("1000000") with
    | Some konto3 -> konto3.Withdraw(8.0)
    | None -> printfn "Nie można wypłacić: konto nie istnieje."

    bank.UpdateAccount("900000", 20000.0)
    bank.UpdateAccount("1000000", 4.0)

    match bank.GetAccount("800000") with
    | Some acc -> printfn "Stan konta: %f" acc.Balance
    | None -> printfn "Nie można sprawdzić: konto nie istnieje."

    bank.DeleteAccount("800000")

mainBank()