namespace RomanNumerals

module Romanize = 
    let toRoman num =
        if num = 1 then
            "I"
        else
            "II"
