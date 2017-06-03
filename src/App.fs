module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Types
open App.State
open Global

// Bulma + Docs site css
importAll "../sass/main.sass"

open Fable.Helpers.React
open Fable.Helpers.React.Props

let root (model:Model) dispatch =

  let pageHtml =
    function
    | Page.About -> About.View.root
    | Docs ->
        Doc.Index.View.view model.docs
    | Samples (Some sampleKey) ->
        model.samples.index 
        |> List.collect (fun c -> c.samples) 
        |> List.tryFind (fun s -> s.title = sampleKey)
        |> Sample.Viewer.View.view  // TODO: use height
    | Samples _ ->
        Sample.Index.View.view model.samples

  div
    []
    [ div
        [ ClassName "navbar-bg" ]
        [ div
            [ ClassName "container" ]
            [ Navbar.View.root ] ]
      div
        [ ]
        [ Header.View.root model.currentPage
          div
            [ ClassName "section" ]
            [ div
                [ ClassName "container" ]
                [ pageHtml model.currentPage ] ] ] ]


open Elmish.React
open Elmish.Debug

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
// #if DEBUG
// |> Program.withDebugger
// #endif
|> Program.run
