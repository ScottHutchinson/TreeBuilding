open BenchmarkDotNet.Running
open TreeBuildingBenchmark

[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<Benchmarks>() |> ignore
    0
