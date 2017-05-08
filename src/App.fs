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
// Prism css
importAll "../css/prism.min.css"

// Import prismjs lib (F# support)
importAll "prismjs/components/prism-core.min.js"
importAll "prismjs/components/prism-clike.min.js"
importAll "prismjs/components/prism-fsharp.min.js"

[<Emit("Prism.languages.fsharp")>]
let prismFSharp = ""

// Configure markdown parser
let options =
  createObj [
    "highlight" ==> fun code -> PrismJS.Globals.Prism.highlight(code, unbox prismFSharp)
    "langPrefix" ==> "language-"
  ]

Marked.Globals.marked.setOptions(unbox options)
|> ignore

open Fable.Helpers.React
open Fable.Helpers.React.Props

let root model dispatch =

  let pageHtml =
    function
    | Page.About -> About.View.root
    | Home -> Home.View.root
    | Docs (Some page) ->
        Doc.Viewer.View.root model.docViewer // TODO: use name
    | Docs _ ->
        Doc.Index.View.root
    | Samples (Some (height,url)) ->
        Sample.Viewer.View.root model.sampleViewer // TODO: use height
    | Samples _ ->
        Sample.Index.View.root

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
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
