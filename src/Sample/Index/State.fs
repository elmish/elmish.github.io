module Sample.Index.State

open Types
open Fable.Core

let sampleReferences =
  Map.empty<string, SampleReference>
    .Add(
      "sample-react-calc",
      { demoUrl = "https://fable-elmish.github.io/sample-react-calc/"
        sourceUrl = "https://github.com/fable-elmish/sample-react-counter"
        height = 300 }
    )
    .Add(
      "sample-react-calc2",
      { demoUrl = ""
        sourceUrl = ""
        height = 300 }
    )
    .Add(
      "sample-react-calc2",
      { demoUrl = ""
        sourceUrl = ""
        height = 300 }
    )
    .Add(
      "sample-react-calc2",
      { demoUrl = ""
        sourceUrl = ""
        height = 300 }
    )
