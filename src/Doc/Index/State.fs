module Doc.Index.State

open Types

let init () =
    { index =
        [ { title = "elmish"
            description =
              """
Defines core abstractions that can be used to build Fable applications following **model view update** style of architecture.
              """
            url = "https://elmish.github.io/elmish/" }
          { title = "elmish-browser"
            description =
              """
Implements **routing** and **navigation** for elmish apps targeting browser (SPAs).
              """
            url = "https://elmish.github.io/browser/" }
          { title = "elmish-debugger"
            description =
              """
Time-traveling **debugger** and **import/export** for elmish applications.
              """
            url = "https://elmish.github.io/debugger/" }
          { title = "elmish-react"
            description =
              """
Build **React** and **ReactNative** apps with elmish.
              """
            url = "https://elmish.github.io/react/" }
          { title = "elmish-hmr"
            description =
              """
**Hot Module Replacement** for Elmish apps
              """
            url = "https://elmish.github.io/hmr/" } ] }
