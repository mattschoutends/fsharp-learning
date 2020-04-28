namespace CommandLine

open System

module CommandLineParser =
    // based on https://fsharpforfunandprofit.com/posts/pattern-matching-command-line/

    let OrderByName = "N"
    let OrderBySize = "S"

    type CommandLineOptions = {
        verbose: bool;
        subdirectories: bool;
        orderby: string;
    }

    let rec parseCommandLine args optionsSoFar = 
        match args with
        | [] -> optionsSoFar
        | "/v"::xs -> parseCommandLine xs {optionsSoFar with verbose=true}
        | "/s"::xs -> parseCommandLine xs {optionsSoFar with subdirectories=true}
        | "/o"::xs ->
            match xs with 
            | "S"::xss -> parseCommandLine xss {optionsSoFar with orderby=OrderBySize}
            | "N"::xss -> parseCommandLine xss {optionsSoFar with orderby=OrderByName} // this looks like it could be turned into a type
            | _ ->
                eprintfn "OrderBy needs a valid second argument"
                parseCommandLine xs optionsSoFar
        | x::xs -> 
            eprintfn "Option '%s' is unrecognized" x // Could have a nice "usage" function...
            parseCommandLine xs optionsSoFar
        

    [<EntryPoint>]
    let main argv =
        let argvList = argv |> Array.toList
        let options = parseCommandLine argvList {
            verbose = false;
            subdirectories = false;
            orderby = OrderByName;
        }
        printfn "Options: %A" options

        printfn "Hello World from F#!"
        0 // return an integer exit code
