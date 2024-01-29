module FirstThreading

open System
open System.Collections.Generic
open System.Diagnostics
open System.IO
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

    writeLine $"Processing chunk #{idx} of {chunk.Length} rows"
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
    writeLine $"Processed chunk #{idx} into {acc.Count} cities in {sw.Elapsed:``h':'mm':'ss'.'fff``}"
    acc

let run filename =
    ewriteLine $"This is FirstThreading.Run \"{filename}\""
    let input = File.ReadAllLines(filename)
    let data = processChunk input 0
    let ks = data.Keys |> Seq.sort
    Console.Write("{")
    for k in ks do
        let d = data[k]
        Console.Write($"{d.City}={d.Min:F1}/{d.Sum/(float d.Count):F1}/{d.Max:F1}, ")
    Console.WriteLine("}");
    input.Length

