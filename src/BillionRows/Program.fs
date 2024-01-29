open System
open System.Diagnostics
open Utilities
open System.Threading

type Runners =
    | Simple = 1
    | FirstThreading = 2

let getRunnerFromName (name: string) =
    match (name.ToLower()) with
    | "simple" -> Some Runners.Simple
    | "firstthreading" -> Some Runners.FirstThreading
    | _ -> None

let executeRunner runner filename =
    let sw = Stopwatch.StartNew()

    match runner with
    | Runners.Simple
        -> ewriteLine $"Running Simple {filename}"
           let rows = Simple.run filename
           ewrite $"Simple completed across {rows:``0,0``} rows "
    | Runners.FirstThreading
        -> writeLine $"Running FirstThreading {filename}"
           // Fiddle factor when developing...
           let p = Environment.ProcessorCount - 2
           let b = ThreadPool.SetMinThreads(p, 2)
           let b = ThreadPool.SetMaxThreads(p+2, 4)
           assert b
           let rows = FirstThreading.run filename
           ewrite $"FirstThreading completed across {rows:``0,0``} rows "
    | _ -> failwith "Unexpect runner id"

    sw.Stop()
    ewriteLine $"in {sw.Elapsed:``h':'mm':'ss'.'fff``}."
    eprintfn $"GC counts 0: {GC.CollectionCount(0)}; 1: {GC.CollectionCount(1)}; 2: {GC.CollectionCount(2)}; "


let usage () =
    ewriteLine "Usage:"
    ewriteLine "  <runner> <input-file>"
    ewriteLine "<runner> is one of \"Simple\", \"FirstThreading\""

[<EntryPoint>]
let main(args) =
    ewriteLine "One NillionRow Challenge runner"

    if args.Length <> 2 then
        ewriteLine "Wrong argument count."
        usage ()
        1
    else
        let rr = getRunnerFromName args[0]
        if Option.isNone rr then
            ewriteLine $"Invalid runner name \"{args[0]}\""
            usage ()
            1
        else
            let runner = rr.Value
            let filename = args[1]

            executeRunner runner filename
            0
