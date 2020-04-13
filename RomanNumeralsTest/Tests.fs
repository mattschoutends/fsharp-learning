module RomanNumeralsTests

open System
open Xunit
open RomanNumerals


[<Fact>]
let ``1 returns I`` () = 
    Assert.Equal("I", Romanize.toRoman 1)
