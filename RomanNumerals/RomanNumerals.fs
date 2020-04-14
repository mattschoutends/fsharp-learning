namespace RomanNumerals

module Romanize = 
    let toRoman num =
        let rec doOnes n = 
            match n with
            | 0 -> ""
            | _ -> "I" + doOnes (n-1) 

        match num with
        | 1 | 2 | 3 -> doOnes num
        | 5 -> "V"
        | 10 -> "X"
        | 50 -> "L"
        | 100 -> "C"
        | _ -> "[shrug emoji]"
