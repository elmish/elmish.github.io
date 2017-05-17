module Sample.Index.State

open Types
open Fable.Core

let sampleReferences =
  Map.empty<string, SampleReference>
    .Add(
      "sample-react-calc",
      { demoUrl = "https://fable-elmish.github.io/sample-react-calc/"
        sourceUrl = "https://github.com/fable-elmish/sample-react-calc"
        height = 500 }
    )
