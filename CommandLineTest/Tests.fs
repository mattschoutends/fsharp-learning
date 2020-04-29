module Tests

open System
open Xunit
open CommandLine.CommandLineParser



[<Fact>]
let ``Basic Parse Test`` () =
    let expected = {
        verbose = VerboseOutput;
        subdirectories = ExcludeSubdirectories;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/v"]
    Assert.Equal(actual, expected)

    let expected = {
        verbose = VerboseOutput;
        subdirectories = IncludeSubdirectories;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/v"; "/s"]
    Assert.Equal(actual, expected)

    let expected = {
        verbose = TerseOutput;
        subdirectories = ExcludeSubdirectories;
        orderby = OrderBySize;
    }
    let actual = parseCommandLine["/o"; "S"]
    Assert.Equal(actual, expected)

[<Fact>]
let ``Parse Command Line with Errors`` () =
    let expected = {
        verbose = VerboseOutput;
        subdirectories = ExcludeSubdirectories;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/v"; "xyz"]
    Assert.Equal(actual, expected)

    let expected = {
        verbose = TerseOutput;
        subdirectories = ExcludeSubdirectories;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/o"; "xyz"]
    Assert.Equal(actual, expected)

    // TODO:  Figure out how to check that logging to stderr happened