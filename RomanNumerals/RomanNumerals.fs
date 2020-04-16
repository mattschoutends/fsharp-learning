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
        