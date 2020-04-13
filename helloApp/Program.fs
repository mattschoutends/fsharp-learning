// Learn more about F# at http://fsharp.org

open System
open startproj.FriendlyString

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    argv
    |> Array.map getHelloString
    |> Array.iter (printfn ("%s"))

    let sampleTable = [ for i in 0 .. 99 -> (i, i*i) ]
    printfn "%A" sampleTable

    let repeater s = s + " " + s + " " + s
    System.Console.WriteLine(repeater "chickens")
    System.Console.WriteLine(repeater)
    printfn "%A" repeater

    0 // return an integer exit code
