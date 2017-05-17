module Sample.Viewer.View

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global

let root reference =

    let sampleReference = Sample.Index.State.sampleReferences.TryFind reference
    match sampleReference with
    | None ->
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
    | Some sample ->
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
                            Href sample.demoUrl
                            Target "_blank" ]
                          [ str "Open in tab" ]
                        a
                          [ ClassName "button is-pulled-right"
                            Href sample.sourceUrl
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
                            Src sample.demoUrl
                            Style [ Height sample.height ] ]
                          [] ] ] ] ]
