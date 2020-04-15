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

[<Theory>]
[<InlineData("XX", 20)>]
[<InlineData("XXI", 21)>]
[<InlineData("XXIV", 24)>]
[<InlineData("XXVI", 26)>]
[<InlineData("XXIX", 29)>]
[<InlineData("XXX", 30)>]
[<InlineData("XLI", 41)>]
[<InlineData("XLVII", 47)>]
[<InlineData("XLIX", 49)>]
let ``20 through 49`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)

[<Theory>]
[<InlineData("L", 50)>]
[<InlineData("LI", 51)>]
[<InlineData("LXXVII", 77)>]
[<InlineData("XC", 90)>]
[<InlineData("XCIV", 94)>]
[<InlineData("XCV", 95)>]
[<InlineData("XCIX", 99)>]
let ``50 through 99`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)

[<Theory>]
[<InlineData("CI", 101)>]
[<InlineData("CXCIX", 199)>]
[<InlineData("CC", 200)>]
[<InlineData("CCCLIV", 354)>]
[<InlineData("CD", 400)>]
[<InlineData("CDIII", 403)>]
[<InlineData("CDV", 405)>]
[<InlineData("CDXCIX", 499)>]
let ``101 through 499`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)

[<Theory>]
[<InlineData("DI", 501)>]
[<InlineData("DX", 510)>]
[<InlineData("DXLIV", 544)>]
[<InlineData("DCCCLIV", 854)>]
[<InlineData("CM", 900)>]
[<InlineData("CMXCI", 991)>]
[<InlineData("CMXCIX", 999)>]
let ``501 through 999`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)

[<Theory>]
[<InlineData("MI", 1001)>] 
[<InlineData("MCMLXXX", 1980)>]
[<InlineData("MCMXCIX", 1999)>]
[<InlineData("MM", 2000)>]
[<InlineData("MMMIV", 3004)>]
let ``More than a thousand`` (roman: string, arabic: int) =
    Assert.Equal(roman, Romanize.toRoman arabic)


