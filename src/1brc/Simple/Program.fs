open System
open System.Diagnostics
open OmeBillion.Simple

[<EntryPoint>]
let main(args) =
    printfn $"iBRC \"Simple\" solution"
    printfn $"Working folder: {Environment.CurrentDirectory}"
    printfn ""

    if args.Length <> 1 then
        eprintfn "Invalid command line"
        eprintfn "Usage"
        eprintfn "  Simple <data-file"
        1
    else
        let filename = args[0]
        printfn $"Reading from \"{filename}\""

        let sw = Stopwatch.StartNew()
        let rows = SimpleProcessor.run filename
        sw.Stop()
        printfn $"Complete with {rows} records in {sw.Elapsed:``h':'mm':'ss'.'fff``}."
        0
