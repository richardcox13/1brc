module FirstThreading

open System
open System.Collections.Generic
open System.Diagnostics
open System.IO
open System.Threading.Tasks
open Utilities

[<Struct>]
type CityData =
    {
        City: string
        Count: int
        Sum: float
        Min: float
        Max: float
    }

type Accumulator = Dictionary<string, CityData>

let processChunk (chunk: string[]) idx =
    let acc = new Accumulator()

    ewriteLine $"Processing chunk #{idx} of {chunk.Length} rows"
    let sw = Stopwatch.StartNew()
    for s in chunk do
        let semiIdx = s.IndexOf(';')
        assert (semiIdx <> -1)
        let city = s[0..(semiIdx-1)]
        let valSpan = s.AsSpan(semiIdx+1)
        let value = Double.Parse(valSpan)

        acc[city] <- match acc.TryGetValue(city) with
                     | (false, _) -> { City = city; Count = 1; Sum = value; Min = value; Max = value }
                     | (true, prev)
                        -> { City = prev.City;
                             Count = prev.Count+1;
                             Sum = prev.Sum + value;
                             Min = min value prev.Min;
                             Max = max value prev.Max }
    sw.Stop()
    ewriteLine $"Processed chunk #{idx} into {acc.Count} cities in {sw.Elapsed:``h':'mm':'ss'.'fff``}"
    acc

let mergeAccumulators (target: Accumulator) (addition: Accumulator) =
    for kv in addition do
        let city = kv.Key
        let value = kv.Value
        target[city] <- match target.TryGetValue(city) with
                        | (false, _) -> { City = city; Count = value.Count; Sum = value.Sum; Min = value.Min; Max = value.Max }
                        | (true, prev)
                            -> { City = city;
                                 Count = prev.Count + value.Count;
                                 Sum = prev.Sum + value.Sum;
                                 Min = (min prev.Min value.Min);
                                 Max = max prev.Max value.Max }
    ()

let showResults (acc: Accumulator) =
    let ks = acc.Keys |> Seq.sort
    Console.Write("{")
    for k in ks do
        let d = acc[k]
        Console.Write($"{d.City}={d.Min:F1}/{d.Sum/(float d.Count):F1}/{d.Max:F1}, ")
    Console.WriteLine("}");

let run filename =
    ewriteLine $"This is FirstThreading.Run \"{filename}\""
    let mutable rowCount = 0

    let sw = Stopwatch.StartNew()
    let eshowProgress (msg: string) =
        ewriteLine $"{sw.Elapsed:``h':'mm':'ss'.'fff``}: {msg}"


    let mutable parseTasks
        = File.ReadLines(filename)
          // TODO: Adjust this chunk size
          |> Seq.chunkBySize 2_700_000
          |> Seq.mapi (fun idx chunk ->
               rowCount <- rowCount + chunk.Length
               let tt = Task.Factory.StartNew(
                       (fun () -> struct (idx, processChunk chunk idx)),
                       TaskCreationOptions.LongRunning
                    )

               ewriteLine $"Created chunk task #{idx}"
               tt
             )
          |> Seq.toArray

    eshowProgress "Built taks"

    let pt
        = parseTasks
          |> Array.map (fun t -> t :> Task)
    let doneTaskIdx = Task.WaitAny(pt)
    let struct (chunkIdx, acc)  = parseTasks[doneTaskIdx].Result
    eshowProgress $"Task #{doneTaskIdx} with chunk {chunkIdx} done"
    parseTasks <- parseTasks |> Array.removeAt doneTaskIdx
    
    while parseTasks.Length > 0 do
        let doneTaskIdx = Task.WaitAny(pt)
        let struct (chunkIdx, nextAcc)  = parseTasks[doneTaskIdx].Result
        eshowProgress $"Task #{doneTaskIdx} with chunk {chunkIdx} done"
        mergeAccumulators acc nextAcc
        parseTasks <- parseTasks |> Array.removeAt doneTaskIdx

    eshowProgress "Chunks processed, results merged"
    showResults acc

    rowCount

