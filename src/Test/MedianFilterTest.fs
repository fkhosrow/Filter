module internal MedianFilterTest

open NUnit.Framework
open FsUnit
open FilterUtility

let oddWindowSize () = 
    let filter = MedianFilter (5)
    // The first 5 values
    let mutable tmp = filter.ProcessValue  1
    tmp |> should equal 0
    tmp <- filter.ProcessValue  4
    tmp |> should equal 0
    tmp <- filter.ProcessValue 2
    tmp |> should equal 0
    tmp <- filter.ProcessValue 5
    tmp |> should equal 0
    tmp <- filter.ProcessValue 0
    tmp |> should equal 2       
    // Moving window 
    tmp <- filter.ProcessValue 8
    tmp |> should equal 4
    tmp <- filter.ProcessValue 3
    tmp |> should equal 3    

let evenWindowSize () = 
    let filter = MedianFilter (4)
    // The first 5 values
    let mutable tmp = filter.ProcessValue  1
    tmp |> should equal 0
    tmp <- filter.ProcessValue  4
    tmp |> should equal 0
    tmp <- filter.ProcessValue 2
    tmp |> should equal 0
    tmp <- filter.ProcessValue 5
    tmp |> should equal 3
    // Moving window     
    tmp <- filter.ProcessValue 0
    tmp |> should equal 3       
    tmp <- filter.ProcessValue 8
    tmp |> should equal 3
    tmp <- filter.ProcessValue 3
    tmp |> should equal 4  








