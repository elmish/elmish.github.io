module Sample.Viewer.View

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global
open Types

let root model =
  let sample =
    // Catch KeyNotFoundException which occured when the markdown
    // content have never been fetched yet
    try
      model.samplesHTML
      |> List.find(fun x ->
        x.sampleKey = model.currentFile
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
    match sample with
    | None -> loader
    | Some sample ->
        match sample.state with
        | Available ->
            div
              [ DangerouslySetInnerHTML {
                  __html = Marked.Globals.marked.parse(sample.html)
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

  // div
  //   [ ClassName "content" ]
  //   [ html ]
  div
    [ ClassName "content" ]
    [ div
        [ ClassName "container" ]
        [ h1
            [ ClassName "has-text-centered" ]
            [ str "Demo" ]
          div
            [ ClassName "columns" ]
            [ div
                [ ClassName "column is-half is-offset-one-quarter has-text-centered" ]
                [ a
                    [ ClassName "button is-primary is-pulled-left"
                      Href sample.Value.sampleKey
                      Target "_blank" ]
                    [ str "Open in tab" ]
                  a
                    [ ClassName "button is-pulled-right"
                      Href ""//(DocGen.githubURL model.CurrentFile)
                      Target "_blank" ]
                    [ span
                        [ ClassName "icon"]
                        [ i
                            [ ClassName "fa fa-github" ]
                            [ ] ]
                      span
                        []
                        [ str "Go to source" ] ]
                  br []
                  br []
                  iframe
                    [ ClassName "sample-viewer"
                      Src sample.Value.sampleKey
                      Style [ Height 300 ] ]
                    [] ] ]
          div
            [ ClassName "content" ]
            [ h1
                [ ClassName "has-text-centered" ]
                [ str "Explanations" ]
              div
                [ ClassName "container" ]
                [ html ] ] ] ]
