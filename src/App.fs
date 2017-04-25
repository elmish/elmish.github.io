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

importAll "../sass/main.sass"
importAll "../css/prism.min.css"

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

let menuItem label page currentPage =
    li
      [ ]
      [ a
          [ classList [ "is-active", page = currentPage ]
            Href (toHash page) ]
          [ str label ] ]

let menu currentPage =
  aside
    [ ClassName "menu" ]
    [ p
        [ ClassName "menu-label" ]
        [ str "General" ]
      ul
        [ ClassName "menu-list" ]
        [ menuItem "Home" Home currentPage
          menuItem "About" Page.About currentPage ] ]

let root model dispatch =

  let pageHtml =
    function
    | Page.About -> About.View.root
    | Home -> Home.View.root
    | Docs subPage ->
        match subPage with
        | DocsPages.Index -> Docs.Index.View.root
        | DocsPages.Viewer name -> Docs.Viewer.View.root model.docsViewer

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
