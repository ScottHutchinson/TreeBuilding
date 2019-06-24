module TreeBuildingBenchmark
open BenchmarkDotNet.Attributes
open TreeBuildingTypes

[<MemoryDiagnoser>]
[<InProcess>]
type Benchmarks () =
    let unbalanced =
        [
            { RecordId = 5; ParentId = 2 };
            { RecordId = 3; ParentId = 2 };
            { RecordId = 2; ParentId = 0 };
            { RecordId = 4; ParentId = 1 };
            { RecordId = 1; ParentId = 0 };
            { RecordId = 0; ParentId = 0 };
            { RecordId = 6; ParentId = 2 }
        ]

    [<Benchmark(Baseline = true)>]
    member __.Baseline () = TreeBuildingBaseline.buildTree unbalanced

    [<Benchmark>]
    member __.Iteration2 () = Iteration2.buildTree unbalanced

    [<Benchmark>]
    member __.Iteration3 () = Iteration3.buildTree unbalanced

    [<Benchmark>]
    member __.Solution () = TreeBuilding.buildTree unbalanced
