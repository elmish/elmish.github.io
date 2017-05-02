module App.State

open Fable.Import.Browser
open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Global
open Types


let pageParser: Parser<Page->Page,_> =
  let curry f = fun a b -> f (a,b)
  oneOf [
    map About (s "about")
    map Home (s "home")
    map (Some >> Docs) (s "docs" </> str)
    map (Docs None) (s "docs")
    map (curry (Some >> Samples)) (s "samples" </> i32 </> str)
    map (Samples None) (s "samples")
    map Home top
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      Fable.Import.Browser.console.log page
      let msg =
        match page with
        | Docs (Some page) ->
            Cmd.ofMsg (DocsViewerMsg (Docs.Viewer.Types.SetDoc page))
        | Docs _ ->
            []
        | _ -> []
      { model with currentPage = page }, msg

let init result =
  let (docsViewer, docsViewerCmd) = Docs.Viewer.State.init ()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        docsViewer = docsViewer }
  model, Cmd.batch [  cmd
                      Cmd.map DocsViewerMsg docsViewerCmd ]

let update msg model =
  match msg with
  | NoOp -> model, []
  | DocsViewerMsg msg ->
      let (docsViewer, docsViewerCmd) = Docs.Viewer.State.update msg model.docsViewer
      { model with docsViewer = docsViewer }, Cmd.map DocsViewerMsg docsViewerCmd
