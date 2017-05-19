module Doc.Index.State

open Types

let init () =
    { index = 
        [ { title = "elmish"
            description =
              """
Defines core abstractions that can be used to build Fable applications following **model view update** style of architecture.
              """
            url = "https://fable-elmish.github.io/elmish/" }
          { title = "elmish-browser"
            description =
              """
Implements **routing** and **navigation** for elmish apps targeting browser (SPAs).
              """
            url = "https://fable-elmish.github.io/browser/" }
          { title = "elmish-debugger"
            description =
              """
Time-traveling **debugger** and **import/export** for fable-elmish applications.
              """
            url = "https://fable-elmish.github.io/debugger/" }
          { title = "elmish-react"
            description =
              """
Build **React** and **ReactNative** apps with elmish.
              """
            url = "https://fable-elmish.github.io/react/" } ] }