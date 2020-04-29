namespace CommandLine

open System

module CommandLineParser =
    // based on https://fsharpforfunandprofit.com/posts/pattern-matching-command-line/

    type OrderByOption = OrderBySize | OrderByName
    type SubdirectoryOption = IncludeSubdirectories | ExcludeSubdirectories
    type VerboseOption = VerboseOutput | TerseOutput

    type CommandLineOptions = {
        verbose: VerboseOption;
        subdirectories: SubdirectoryOption;
        orderby: OrderByOption;
    }

    let rec parseCommandLineRec args optionsSoFar = 
        match args with
        | [] -> optionsSoFar
        | "/v"::xs -> parseCommandLineRec xs {optionsSoFar with verbose=VerboseOutput}
        | "/s"::xs -> parseCommandLineRec xs {optionsSoFar with subdirectories=IncludeSubdirectories}
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
            verbose = TerseOutput;
            subdirectories = ExcludeSubdirectories;
            orderby = OrderByName;
        }
        parseCommandLineRec args defaultArgs
        

    [<EntryPoint>]
    let main argv =
        let argvList = argv |> Array.toList
        let options = parseCommandLine argvList 

        printfn "Options: %A" options

        printfn "Hello World from F#!"
        0 // return an integer exit code
