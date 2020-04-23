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