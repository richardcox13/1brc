open System

[<EntryPoint>]
let main(args) =
    printfn $"iBRC CreateData"
    printfn $"Working folder: {Environment.CurrentDirectory}"
    printfn ""

    if args.Length <> 1 then
        eprintfn "Invalid command line"
        eprintfn "Usage:"
        eprintfn "  CreateData <count>"
        1
    else
        let count = Int32.Parse(args[0])
        printfn $"Creating {count} rows"
        0
