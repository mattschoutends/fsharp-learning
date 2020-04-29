module Tests

open System
open Xunit
open CommandLine.CommandLineParser



[<Fact>]
let ``Basic Parse Test`` () =
    let expected = {
        verbose = true;
        subdirectories = false;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/v"]
    Assert.Equal(actual, expected)

    let expected = {
        verbose = true;
        subdirectories = true;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/v"; "/s"]
    Assert.Equal(actual, expected)

    let expected = {
        verbose = false;
        subdirectories = false;
        orderby = OrderBySize;
    }
    let actual = parseCommandLine["/o"; "S"]
    Assert.Equal(actual, expected)

[<Fact>]
let ``Parse Command Line with Errors`` () =
    let defaultOptions = {
        verbose = false;
        subdirectories = false;
        orderby = OrderByName;
    }

    let expected = {
        verbose = true;
        subdirectories = false;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/v"; "xyz"]
    Assert.Equal(actual, expected)

    let expected = {
        verbose = false;
        subdirectories = false;
        orderby = OrderByName;
    }
    let actual = parseCommandLine["/o"; "xyz"]
    Assert.Equal(actual, expected)

    // TODO:  Figure out how to check that logging to stderr happened