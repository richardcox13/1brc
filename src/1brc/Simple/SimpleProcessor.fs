module OmeBillion.Simple.SimpleProcessor

open System
open System.Collections.Generic
open System.IO

[<Struct>]
type InputRecord =
    {
        City: string
        Value: float
    }


[<Struct>]
type Accumulator =
    {
        City: string
        Count: int
        Sum: float
        Min: float
        Max: float
    }

let parseOneRecord (record: string) =
    let fs = record.Split(';')
    assert (fs.Length = 2)
    let city = fs[0]
    let value = Double.Parse(fs[1])
    { City = city; Value = value}

let run filename =

    let records
        = File.ReadLines(filename)
          |> Seq.map (fun r -> parseOneRecord r)

    let mutable count = 0
    let data = new Dictionary<string, Accumulator>()
    for r in records do
        data[r.City] <- match data.TryGetValue(r.City) with
                        | (false, _) -> { City = r.City; Count = 1; Sum = r.Value; Min = r.Value; Max = r.Value }
                        | (true, prev)
                            -> { City = prev.City;
                                 Count = prev.Count+1;
                                 Sum = prev.Sum + r.Value;
                                 Min = min r.Value prev.Min;
                                 Max = max r.Value prev.Max }

        count <- count+1

    let ks = data.Keys |> Seq.sort
    Console.Write("{")
    for k in ks do
        let d = data[k]
        Console.Write($"{d.City}={d.Min:F1}/{d.Sum/(float d.Count):F1}/{d.Max:F1}, ")
    Console.WriteLine("}");
    count
