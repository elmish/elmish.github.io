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
            Cmd.ofMsg (DocViewerMsg (Doc.Viewer.Types.SetDoc page))
        | Docs _ ->
            []
        | _ -> []
      { model with currentPage = page }, msg

let init result =
  let (docViewer, docViewerCmd) = Doc.Viewer.State.init ()
  let (sampleViewer, sampleViewerCmd) = Sample.Viewer.State.init ()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        docViewer = docViewer
        sampleViewer = sampleViewer }
  model, Cmd.batch [  cmd
                      Cmd.map DocViewerMsg docViewerCmd
                      Cmd.map SampleViewerMsg sampleViewerCmd ]

let update msg model =
  match msg with
  | NoOp -> model, []
  | DocViewerMsg msg ->
      let (docViewer, docViewerCmd) = Doc.Viewer.State.update msg model.docViewer
      { model with docViewer = docViewer }, Cmd.map DocViewerMsg docViewerCmd
  | SampleViewerMsg msg ->
      let (sampleViewer, sampleViewerCmd) = Sample.Viewer.State.update msg model.sampleViewer
      { model with sampleViewer = sampleViewer }, Cmd.map SampleViewerMsg sampleViewerCmd
