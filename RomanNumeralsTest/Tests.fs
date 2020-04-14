module RomanNumeralsTests

open System
open Xunit
open RomanNumerals


[<Theory>]
[<InlineData("I", 1)>]
[<InlineData("V", 5)>]
[<InlineData("X", 10)>]
[<InlineData("L", 50)>]
[<InlineData("C", 100)>]
let ``Basic Roman Numerals I through M`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)

[<Fact>]
let ``2 returns II`` () =
    Assert.Equal("II", Romanize.toRoman 2)

[<Fact>]
let ``3 returns III`` () =
    Assert.Equal("III", Romanize.toRoman 3)
