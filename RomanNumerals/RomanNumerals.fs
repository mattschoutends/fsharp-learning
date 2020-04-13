namespace RomanNumerals

module Romanize = 
    let toRoman num =
        let rec doOnes n = 
            match n with
            | 0 -> ""
            | _ -> "I" + doOnes (n-1) 
        
        doOnes num

