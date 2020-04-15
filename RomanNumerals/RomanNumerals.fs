namespace RomanNumerals

module Romanize = 
    let rec toRoman num =
        let rec doOnes n = 
            match n with
            | 0 -> ""
            | _ -> "I" + doOnes (n-1) 

        match num with
        | n when n < 4 -> doOnes num
        | 4 -> "IV"
        | n when 5 <= n && n < 9 -> "V" + toRoman (n-5)
        | 9 -> "IX"
        | 10 -> "X"
        | n when 10 < n && n < 19 -> "X" + toRoman (n-10)
        | 19 -> "XIX"
        | 50 -> "L"
        | 100 -> "C"
        | 500 -> "D"
        | 1000 -> "M"
        | _ -> "[shrug emoji]"

        // Thinking there's a way to compress the ranges a bit...
        // Also thinking there might be a way to tuple up the data
        // Some rules:  Only I, X, C can be subtracted
        // Only can subtract from the next two higher "digits"
        // So I can be subtracted from V, X
        // ...X can be subtracted from L, C
        // ...C can be subtracted from D, M
