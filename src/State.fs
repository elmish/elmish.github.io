module App.State

open Fable.Import.Browser
open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Global
open Types


let pageParser: Parser<Page->Page,_> =
  oneOf [
    map About (s "about")
    map Home (s "home")
    map Docs (s "docs")
    map (Some >> Samples) (s "samples" </> str)
    map (Samples None) (s "samples")
    map Home top
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      let msg =
        match page with
        | Samples (Some infos) ->
            Cmd.ofMsg (SampleViewerMsg (Sample.Viewer.Types.SetSample infos))
        | _ -> []
      { model with currentPage = page }, msg

let init result =
  let (sampleViewer, sampleViewerCmd) = Sample.Viewer.State.init ()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        sampleViewer = sampleViewer }
  model, Cmd.batch [  cmd
                      Cmd.map SampleViewerMsg sampleViewerCmd ]

let update msg model =
  match msg with
  | NoOp -> model, []
  | SampleViewerMsg msg ->
      let (sampleViewer, sampleViewerCmd) = Sample.Viewer.State.update msg model.sampleViewer
      { model with sampleViewer = sampleViewer }, Cmd.map SampleViewerMsg sampleViewerCmd
