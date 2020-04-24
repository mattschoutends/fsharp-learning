namespace RomanNumerals

module Romanize = 
    let rec toRoman num =
        let numerals = [(1000, "M"); (900, "CM"); (500, "D"); (400, "CD"); (100, "C"); 
                        (90, "XC"); (50, "L"); (40, "XL"); (10, "X"); 
                        (9, "IX"); (5, "V"); (4, "IV"); (1, "I")]
        
        let romanAppend n t =
            let arabic = fst t
            let roman = snd t
            roman + toRoman (n-arabic)

        match num with
        | 0 -> ""
        | _ -> numerals
            |> List.tryFind( fun (arabic, roman) -> arabic <= num )
            |> Option.get
            |> romanAppend num

module RomanTwo = 
    // From F# for fun and profit, trying their Roman to Arabic example
    // Doesn't use xUnit test cases, and I've been having trouble with 
    // the discriminated union as a parameter to InlineData.
    type RomanDigit = I | V | X | L | C | D | M
    type RomanNumeral = RomanNumeral of RomanDigit list

    let digitToInt = 
        function
        | I -> 1
        | V -> 5
        | X -> 10
        | L -> 50
        | C -> 100
        | D -> 500
        | M -> 1000

    let rec digitsToInt =
        function
        | [] -> 0
        | smaller::larger::ns when smaller < larger ->
            (digitToInt larger - digitToInt smaller) + digitsToInt ns
        | digit::ns -> digitToInt digit + digitsToInt ns 

    let toInt (RomanNumeral digits) = digitsToInt digits

    type ParsedChar =
        | Digit of RomanDigit
        | BadChar of char 

    let charToRomanDigit = 
        function
        | 'I' -> Digit I
        | 'V' -> Digit V
        | 'X' -> Digit X
        | 'L' -> Digit L
        | 'C' -> Digit C
        | 'D' -> Digit D
        | 'M' -> Digit M
        | ch -> BadChar ch

    let toRomanDigitList (s:string) = 
        s.ToCharArray()
        |> List.ofArray
        |> List.map charToRomanDigit

    let toRomanNumeral s =
        toRomanDigitList s
        |> List.choose (
            function
            | Digit digit -> Some digit
            | BadChar ch -> 
                eprintf "%c is not a valid character" ch
                None
        )
        |> RomanNumeral

    let runsAllowed =
        function
        | I | X | C | M -> true
        | V | L | D -> false

    let noRunsAllowed = runsAllowed >> not

    let rec isValidDigitList digitList =
        match digitList with
        | [] -> true
        | d1::d2::d3::d4::d5::_
            when d1=d2 && d1=d3 && d1=d4 && d1=d5 ->
                false
        | d1::d2::_
            when d1=d2 && noRunsAllowed d1 ->
                false 
        | d1::d2::d3::d4::higher::ds
            when d1=d2 && d1=d3 && d1=d4
            && runsAllowed d1
            && higher > d1 ->
                false
        | d1::d2::d3::higher::ds
            when d1=d2 && d1=d3
            && runsAllowed d1
            && higher > d1 ->
                false
        | d1::d2::higher::ds
            when d1=d2  
            && runsAllowed d1
            && higher > d1 ->
                false
        | d1::d2::d3::_
            when d1 < d2 && d2 <= d3 ->
                false
        | _::ds ->
            isValidDigitList ds

    let isValid (RomanNumeral digitList) = 
        isValidDigitList digitList

module RomanThree =
    type RomanDigit3 =
        | I | II | III | IIII
        | IV | V
        | IX | X | XX | XXX | XXXX
        | XL | L
        | XC | C | CC | CCC | CCCC
        | CD | D
        | CM | M | MM | MMM | MMMM

    let digitToInt3 = 
        function
        | I -> 1 | II -> 2 | III -> 3 | IIII -> 4
        | IV -> 4 | V -> 5
        | IX -> 9 | X -> 10 | XX -> 20 | XXX -> 30 | XXXX -> 40
        | XL -> 40 | L -> 50
        | XC -> 90 | C -> 100 | CC -> 200 | CCC -> 300 | CCCC -> 400
        | CD -> 400 | D -> 500
        | CM -> 900 | M -> 1000 | MM -> 2000 | MMM -> 3000 | MMMM -> 4000

    let digitsToInt3 list = 
        list |> List.sumBy digitToInt3

    type RomanNumeral3 = RomanNumeral3 of RomanDigit3 list

    let toInt3 (RomanNumeral3 digits) =
        digitsToInt3 digits

    type ParsedChar3 =
        | Digit of RomanDigit3
        | BadChar of char

    let rec toRomanDigitListRec charList = 
        match charList with
        | 'I'::'I'::'I'::'I'::ns -> Digit IIII :: toRomanDigitListRec ns
        | 'X'::'X'::'X'::'X'::ns -> Digit XXXX :: toRomanDigitListRec ns
        | 'C'::'C'::'C'::'C'::ns -> Digit CCCC :: toRomanDigitListRec ns
        | 'M'::'M'::'M'::'M'::ns -> Digit MMMM :: toRomanDigitListRec ns
        | 'I'::'I'::'I'::ns -> Digit III :: toRomanDigitListRec ns
        | 'X'::'X'::'X'::ns -> Digit XXX :: toRomanDigitListRec ns
        | 'C'::'C'::'C'::ns -> Digit CCC :: toRomanDigitListRec ns
        | 'M'::'M'::'M'::ns -> Digit MMM :: toRomanDigitListRec ns
        | 'I'::'I'::ns -> Digit II :: toRomanDigitListRec ns
        | 'X'::'X'::ns -> Digit XX :: toRomanDigitListRec ns
        | 'C'::'C'::ns -> Digit CC :: toRomanDigitListRec ns
        | 'M'::'M'::ns -> Digit MM :: toRomanDigitListRec ns

        | 'I'::'V'::ns -> Digit IV :: toRomanDigitListRec ns
        | 'I'::'X'::ns -> Digit IX :: toRomanDigitListRec ns
        | 'X'::'L'::ns -> Digit XL :: toRomanDigitListRec ns
        | 'X'::'C'::ns -> Digit XC :: toRomanDigitListRec ns
        | 'C'::'D'::ns -> Digit CD :: toRomanDigitListRec ns
        | 'C'::'M'::ns -> Digit CM :: toRomanDigitListRec ns

        | 'I'::ns -> Digit I :: toRomanDigitListRec ns
        | 'V'::ns -> Digit V :: toRomanDigitListRec ns
        | 'X'::ns -> Digit X :: toRomanDigitListRec ns
        | 'L'::ns -> Digit L :: toRomanDigitListRec ns
        | 'C'::ns -> Digit C :: toRomanDigitListRec ns
        | 'D'::ns -> Digit D :: toRomanDigitListRec ns
        | 'M'::ns -> Digit M :: toRomanDigitListRec ns

        | badChar::ns -> BadChar badChar :: toRomanDigitListRec ns
        | [] -> []

    let toRomanDigitList3 (s:string) = 
        s.ToCharArray()
        |> List.ofArray
        |> toRomanDigitListRec
    
    let toRomanNumeral3 s =
        toRomanDigitList3 s
        |> List.choose(
            function
            | Digit digit -> Some digit
            | BadChar ch -> 
                eprintfn "%c is not a valid character" ch
                None
        )
        |> RomanNumeral3