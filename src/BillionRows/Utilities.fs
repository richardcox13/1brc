module Utilities

open System

let write (msg: string) = Console.Write(msg)
let writeLine (msg: string) = Console.WriteLine(msg)
let ewrite (msg: string) = Console.Error.Write(msg)
let ewriteLine (msg: string) = Console.Error.WriteLine(msg)
