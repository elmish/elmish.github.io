module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map About (s "about")
    map Home (s "home")
    map Home (s "")
    map (Docs DocsPages.Index) (s "docs")
    map (fun name -> name |> DocsPages.Viewer |> Docs) (s "docs" </> str)
    map (Samples SamplesPages.Index) (s "samples")
    map (fun url height -> (url, height) |> SamplesPages.Viewer |> Samples) (s "samples" <?> stringParam "url" <?> intParam "height")
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
        | Docs subPage ->
            match subPage with
            | DocsPages.Index -> []
            | DocsPages.Viewer fileName ->
                Cmd.ofMsg (DocsViewerMsg (Docs.Viewer.Types.SetDoc fileName))
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
