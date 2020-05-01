namespace CatFacts

open System
open CatFactClient

module app =

    [<EntryPoint>]
    let main argv =
        let fact = getCatFact ()
        printfn "Your daily cat fact:\n\t%s\n" fact
        0 // return an integer exit code
