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
        | n when 10 <= n && n <= 39 -> "X" + toRoman (n-10)
        | n when 40 <= n && n <= 49 -> "XL" + toRoman (n-40)
        | n when 50 <= n && n <= 89 -> "L" + toRoman (n-50)
        | n when 90 <= n && n <= 99 -> "XC" + toRoman (n-90)
        | n when 100 <= n && n <= 399 -> "C" + toRoman (n-100)
        | n when 400 <= n && n <= 499 -> "CD" + toRoman (n-400)
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
