module FilterUtility

open FSharp.Core

/// A moving median filter with a windowSize
type MedianFilter (windowSize : int) =
    let mutable buffer = Array.create windowSize 0
    let mutable currentIndex = 0
    let bufferSize = windowSize

    /// Finds the median of a sorted array
    member private __.Median (input : int []) = 
        let middleIndex = input.Length / 2
        if input.Length % 2 = 0 then
            // Take the average of the two middle indices
            let tmp1 = input.[middleIndex]
            let tmp2 = input.[middleIndex-1]
            (tmp1+tmp2) / 2
        else
            input.[middleIndex]

    member __.ProcessValue (value : int) =   
        // If the buffer is not full, fill it
        if currentIndex < bufferSize-1 then
            buffer.[currentIndex] <- value
            currentIndex <- currentIndex + 1
            0
        else if currentIndex = bufferSize-1 then
            buffer.[currentIndex] <- value
            currentIndex <- currentIndex + 1
            let sortedBuffer = Array.sort buffer
            __.Median sortedBuffer
        else
            for i in 0 .. windowSize-2 do
                buffer.[i] <- buffer.[i+1]
            buffer.[windowSize-1] <- value

            let sortedBuffer = Array.sort buffer
            __.Median sortedBuffer