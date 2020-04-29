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

    let rec parseCommandLineRec args optionsSoFar = 
        match args with
        | [] -> optionsSoFar
        | "/v"::xs -> parseCommandLineRec xs {optionsSoFar with verbose=true}
        | "/s"::xs -> parseCommandLineRec xs {optionsSoFar with subdirectories=true}
        | "/o"::xs ->
            match xs with 
            | "S"::xss -> parseCommandLineRec xss {optionsSoFar with orderby=OrderBySize}
            | "N"::xss -> parseCommandLineRec xss {optionsSoFar with orderby=OrderByName} // this looks like it could be turned into a type
            | _ ->
                eprintfn "OrderBy needs a valid second argument"
                parseCommandLineRec xs optionsSoFar
        | x::xs -> 
            eprintfn "Option '%s' is unrecognized" x // Could have a nice "usage" function...
            parseCommandLineRec xs optionsSoFar

    let parseCommandLine args = 
        let defaultArgs = {
            verbose = false;
            subdirectories = false;
            orderby = OrderByName;
        }
        parseCommandLineRec args defaultArgs
        

    [<EntryPoint>]
    let main argv =
        let argvList = argv |> Array.toList
        let options = parseCommandLineRec argvList {
            verbose = false;
            subdirectories = false;
            orderby = OrderByName;
        }
        printfn "Options: %A" options

        printfn "Hello World from F#!"
        0 // return an integer exit code
