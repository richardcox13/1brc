open System

type Runners =
    | Simple = 1
    | FirstThreading = 2

let write (msg: string) = Console.Write(msg)
let writeLine (msg: string) = Console.WriteLine(msg)
let ewrite (msg: string) = Console.Error.Write(msg)
let ewriteLine (msg: string) = Console.Error.WriteLine(msg)

let getRunnerFromName (name: string) =
    match (name.ToLower()) with
    | "simple" -> Some Runners.Simple
    | "firstthreading" -> Some Runners.FirstThreading
    | _ -> None

let executeRunner runner filename =
    match runner with
    | Runners.Simple
        -> writeLine "Running Simple {filename}"
           0
    | Runners.FirstThreading
        -> writeLine "Running FirstThreading {filename}"
           0
    | _ -> failwith "Unexpect runner id"

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
