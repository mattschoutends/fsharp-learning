// Learn more about F# at http://fsharp.org

open System
open startproj.FriendlyString

[<EntryPoint>]
let main argv =
    let (|MultOf3|_|) i = if i % 3 = 0 then Some MultOf3 else None
    let (|MultOf5|_|) i = if i % 5 = 0 then Some MultOf5 else None

    let fizzbuzz i = 
        match i with
        | MultOf3 & MultOf5 -> "FizzBuzz"
        | MultOf3 -> "Fizz"
        | MultOf5 -> "Buzz"
        | _ -> sprintf "%i" i

    [1..20]
    |> List.map fizzbuzz
    |> List.iter (fun x -> printfn "%s" x)


    0 // return an integer exit code
