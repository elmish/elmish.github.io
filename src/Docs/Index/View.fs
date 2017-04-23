module Docs.Index.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global
open Types

let tileDocs info =
  div
    [ ClassName "tile is-parent is-vertical" ]
    [ article
        [ ClassName "tile is-child notification" ]
        [ p
            [ ClassName "title" ]
            [ a
                [ Href (toHash (Docs (DocsPages.Viewer info.fileName))) ]
                [ str info.title ] ]
          p
            [ ClassName "subtitle" ]
            [ str info.description ] ] ]

let tileVertical tiles =
  div
    [ ClassName "tile is-vertical is-6" ]
    (tiles |> List.map tileDocs)

let root =
  div
    [ ClassName "section" ]
    [ div
        [ ClassName "tile is-ancestor" ]
        [ tileVertical
            [ { title = "Hot Module Replacement (HMR)"
                description = "Hot Module Reloading, or Replacement, is a feature where you inject update modules in a running application.
                            This opens up the possibility to time travel in the application without losing context.
                            It also makes it easier to try out changes in the functionality while retaining the state of the application."
                fileName = "getting_started"
              }
            ]
          tileVertical
            [ ] ] ]
