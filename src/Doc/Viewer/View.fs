module Doc.Viewer.View

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global
open Types

let root model =
  let doc =
    // Catch KeyNotFoundException which occured when the markdown
    // content have never been fetched yet
    try
      model.docsHTML
      |> List.find(fun x ->
        x.fileName = model.currentFile
      )
      |> Some
    with _ -> None

  let loader =
    div
      [ ClassName "has-text-centered" ]
      [ i
          [ ClassName "fa fa-spinner fa-pulse fa-3x fa-fw" ]
          []
      ]

  let html =
    match doc with
    | None -> loader
    | Some doc ->
        match doc.state with
        | Available ->
            div
              [ DangerouslySetInnerHTML {
                  __html = Marked.Globals.marked.parse(doc.html)
                } ]
              [ ]
        | Pending -> loader
        | State.Error ->
            article
              [ ClassName "message is-danger" ]
              [ div
                  [ ClassName "message-body has-text-centered" ]
                  [ str "Sorry an error occured."
                    br [ ]
                    str "If the problem persist please "
                    a
                      [ Href "https://github.com/fable-elmish/fable-elmish.github.io" ]
                      [ str "open an issue." ] ] ]

  div
    [ ClassName "content" ]
    [ html ]
