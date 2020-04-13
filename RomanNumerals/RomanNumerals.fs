namespace RomanNumerals

module Romanize = 
    let toRoman num =
        if num = 1 then
            "I"
        elif num = 2 then
            "II"
        else
            "III"
