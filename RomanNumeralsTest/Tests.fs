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
[<InlineData("D", 500)>]
[<InlineData("M", 1000)>]
let ``Basic Roman Numerals I through M`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)

[<Fact>]
let ``2 returns II`` () =
    Assert.Equal("II", Romanize.toRoman 2)

[<Fact>]
let ``3 returns III`` () =
    Assert.Equal("III", Romanize.toRoman 3)

[<Fact>]
let ``4 returns IV`` () =
    Assert.Equal("IV", Romanize.toRoman 4)

[<Theory>]
[<InlineData("VI", 6)>]
[<InlineData("VII", 7)>]
[<InlineData("VIII", 8)>]
let ``6 through 8`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)

[<Fact>]
let ``9 returns IX`` () =
    Assert.Equal("IX", Romanize.toRoman 9)

[<Theory>]
[<InlineData("XI", 11)>]
[<InlineData("XII", 12)>]
[<InlineData("XIII", 13)>]
[<InlineData("XIV", 14)>]
[<InlineData("XV", 15)>]
[<InlineData("XVI", 16)>]
[<InlineData("XVII", 17)>]
[<InlineData("XVIII", 18)>]
[<InlineData("XIX", 19)>]
let ``11 through 19`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)