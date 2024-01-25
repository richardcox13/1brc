open System
open System.Diagnostics
open OmeBillion.Simple

[<EntryPoint>]
let main(args) =
    eprintfn $"iBRC \"Simple\" solution"
    eprintfn $"Working folder: {Environment.CurrentDirectory}"
    eprintfn ""

    if args.Length <> 1 then
        eprintfn "Invalid command line"
        eprintfn "Usage"
        eprintfn "  Simple <data-file"
        1
    else
        let filename = args[0]
        eprintfn $"Reading from \"{filename}\""

        let sw = Stopwatch.StartNew()
        let rows = SimpleProcessor.run filename
        sw.Stop()
        eprintfn $"Complete with {rows:``0,0``} records in {sw.Elapsed:``h':'mm':'ss'.'fff``}."
        eprintfn $"GC counts 0: {GC.CollectionCount(0)}; 1: {GC.CollectionCount(1)}; 2: {GC.CollectionCount(2)}; "

        0
