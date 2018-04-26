module Sample.Index.State

open Types
open Fable.Core

let init () =
  let basicSamples =
      [ { demoUrl = "https://elmish.github.io/sample-react-counter/"
          title = "counter"
          description = "counter ported from Elm"
          sourceUrl = "https://github.com/elmish/sample-react-counter"
          height = 500 }
        { demoUrl = "https://elmish.github.io/sample-react-navigation/"
          title = "navigation"
          description = "navigation sample ported from Elm"
          sourceUrl = "https://github.com/elmish/sample-react-navigation"
          height = 500 }
        // { demoUrl = "https://elmish.github.io/sample-react-counter-list/"
        //   title = "counter-list"
        //   description = "parent-child composition"
        //   sourceUrl = "https://github.com/elmish/sample-react-counter-list"
        //   height = 500 } ]
      ]
  let intermediateSamples = 
      [ { demoUrl = "https://elmish.github.io/sample-react-todomvc/"
          title = "TodoMVC"
          description = "TodoMVC ported from Elm"
          sourceUrl = "https://github.com/elmish/sample-react-todomvc"
          height = 500 }
        { demoUrl = "https://elmish.github.io/sample-react-timer-svg/"
          title = "timer-svg"
          description = "Timer as a source of events"
          sourceUrl = "https://github.com/elmish/sample-react-timer-svg"
          height = 500 }
        { demoUrl = "https://elmish.github.io/sample-react-fifteen-puzzle/"
          title = "15"
          description = "Classic 15 puzzle"
          sourceUrl = "https://github.com/elmish/sample-react-fifteen-puzzle"
          height = 500 }
        { demoUrl = "https://elmish.github.io/sample-react-memory-game/"
          title = "memory"
          description = "Classic Memory game"
          sourceUrl = "https://github.com/elmish/sample-react-memory-game"
          height = 500 }
        { demoUrl = "https://elmish.github.io/sample-react-calc/"
          title = "calc"
          description = "Calculator sample"
          sourceUrl = "https://github.com/elmish/sample-react-calc"
          height = 500 } ]
  let complexSamples = 
      [ 
        // { demoUrl = ""
        //   title = "fable-suave-scaffold"
        //   description = "Working sample of a Suave + Fable + Elmish"
        //   sourceUrl = "https://github.com/fable-compiler/fable-suave-scaffold"
        //   height = 500 } 
      ]
   
  { index =
      [ { title = "Basic"
          samples = basicSamples }

        { title = "Intermediate"
          samples = intermediateSamples } 

        { title = "Complex"
          samples = complexSamples } ] }
