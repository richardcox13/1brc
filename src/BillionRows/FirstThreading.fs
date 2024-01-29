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

let run filename =
    ewriteLine $"This is FirstThreading.Run \"{filename}\""
    let mutable rowCount = 0

    let sw = Stopwatch.StartNew()
    let parseTasks
        = File.ReadLines(filename)
          // TODO: Adjust this chunk size
          |> Seq.chunkBySize 2_700_000
          |> Seq.mapi (fun idx chunk ->
               rowCount <- rowCount + chunk.Length
               let tt = new Task<Accumulator>(
                       (fun () -> processChunk chunk idx),
                       TaskCreationOptions.LongRunning
                    )

               ewriteLine $"Created chunk task #{idx}"
               tt
             )
          |> Seq.toArray

    let pt
        = parseTasks
          |> Array.map (fun t ->
                                 t.Start()
                                 t :> Task)
    Task.WaitAll(pt)

    ewriteLine $"Processed chunks in {sw.Elapsed:``h':'mm':'ss'.'fff``}"

    // TEMP just read the first chunk's data
    let data = parseTasks[0].Result
    let ks = data.Keys |> Seq.sort
    Console.Write("{")
    for k in ks do
        let d = data[k]
        Console.Write($"{d.City}={d.Min:F1}/{d.Sum/(float d.Count):F1}/{d.Max:F1}, ")
    Console.WriteLine("}");
    rowCount

