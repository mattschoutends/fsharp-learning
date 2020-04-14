module RomanNumeralsTests

open System
open Xunit
open RomanNumerals


[<Fact>]
let ``1 returns I`` () = 
    Assert.Equal("I", Romanize.toRoman 1)

[<Fact>]
let ``2 returns II`` () =
    Assert.Equal("II", Romanize.toRoman 2)

[<Fact>]
let ``3 returns III`` () =
    Assert.Equal("III", Romanize.toRoman 3)

[<Fact>]
let ``5 returns V`` () =
    Assert.Equal("V", Romanize.toRoman 5)
