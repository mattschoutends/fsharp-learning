namespace RomanNumerals

module Romanize = 
    let rec toRoman num =
        let rec doOnes n = 
            match n with
            | 0 -> ""
            | _ -> "I" + doOnes (n-1) 

        match num with
        | 1 | 2 | 3 -> doOnes num
        | 5 -> "V"
        | n when 5 < n && n < 10 -> "V" + toRoman (n-5)
        | 10 -> "X"
        | 50 -> "L"
        | 100 -> "C"
        | 500 -> "D"
        | 1000 -> "M"
        | 4 -> "IV"
        | _ -> "[shrug emoji]"
