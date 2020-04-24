module RomanNumeralsTests3

open System
open Xunit

open RomanNumerals.RomanThree

[<Fact>]
let ``R3 digit to int`` () =
    Assert.Equal(I |> digitToInt3, 1)
    Assert.Equal(III |> digitToInt3, 3)
    Assert.Equal(V |> digitToInt3, 5)
    Assert.Equal(CM |> digitToInt3, 900)

[<Fact>]
let ``R3 list of digits to int`` () =
    Assert.Equal([IIII] |> digitsToInt3, 4)
    Assert.Equal([IV] |> digitsToInt3, 4)
    Assert.Equal([V;I] |> digitsToInt3, 6)
    Assert.Equal([IX] |> digitsToInt3, 9)
    Assert.Equal([M;CM;L;X;X;IX] |> digitsToInt3, 1979)
    Assert.Equal([M;CM;XL;IV] |> digitsToInt3, 1944)

[<Fact>]
let ``R3 RomanNumeral to integer`` () =
    Assert.Equal( RomanNumeral3 [IIII] |> toInt3, 4)
    Assert.Equal( RomanNumeral3 [M;CM;L;XX;IX] |> toInt3, 1979)

[<Fact>]
let ``R3 parsing`` () =
    Assert.Equal("IIII" |> toRomanNumeral3, RomanNumeral3 [IIII])
    Assert.Equal("IV" |> toRomanNumeral3, RomanNumeral3[IV])
    Assert.Equal("VI" |> toRomanNumeral3, RomanNumeral3 [V;I])
    Assert.Equal("IX" |> toRomanNumeral3, RomanNumeral3 [IX])
    Assert.Equal("MCMLXXIX" |> toRomanNumeral3, RomanNumeral3 [M;CM;L;XX;IX])
    Assert.Equal("MCMXLIV" |> toRomanNumeral3, RomanNumeral3 [M;CM;XL;IV])
    Assert.Equal("MC?I" |> toRomanNumeral3, RomanNumeral3 [M;C;I])
    Assert.Equal("abc" |> toRomanNumeral3, RomanNumeral3 [])

[<Theory>]
[<InlineData("IIII", true)>]
[<InlineData("IV", true)>]
[<InlineData("", true)>]
[<InlineData("IIXX", false)>]
[<InlineData("VV", false)>]
let ``R3 validation`` (romanString, valid) =
    Assert.Equal(romanString |> toRomanNumeral3 |> isValid3, valid)
