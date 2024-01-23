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


type Accumulator =
    {
        City: string
        Count: int
        Sum: float
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
                        | (false, _) -> { City = r.City; Count = 1; Sum = r.Value }
                        | (true, prev) -> { prev with Count = prev.Count+1; Sum = prev.Sum + r.Value }

        count <- count+1

    count
