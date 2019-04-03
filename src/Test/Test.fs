[<EntryPoint>]
let main argv =
    // Run tests
    MedianFilterTest.oddWindowSize ()
    MedianFilterTest.evenWindowSize ()
    0 // return an integer exit code
