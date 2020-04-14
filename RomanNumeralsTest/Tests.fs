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

[<Fact>]
let ``10 returns X`` () =
    Assert.Equal("X", Romanize.toRoman 10)

[<Fact>]
let ``50 returns L`` () =
    Assert.Equal("L", Romanize.toRoman 50)

[<Fact>]
let ``100 returns C`` () =
    Assert.Equal("C", Romanize.toRoman 100)