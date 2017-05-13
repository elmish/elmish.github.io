module Sample.Viewer.State

open Elmish
open Fable.PowerPack
open Fable.PowerPack.Fetch
open Types
open Global
open Fable.Import

let init () =
  { currentFile = ""
    samplesHTML = [] }, []

let createEmptySampleHtml sampleKey =
  { sampleKey = sampleKey
    html = ""
    state = Available }

let fetchMarkdown fileName =
  promise {
    let! res = fetch (createDocFilesDirectoryURL fileName) []
    let! txt = res.text()
    return Marked.Globals.marked.parse txt
  }

let update msg model =
  match msg with
  | SetSample sampleKey ->
      // Fetch the markdown content only if unkown doc entry
      let exist =
        model.samplesHTML
        |> List.exists(fun x -> x.sampleKey = sampleKey )

      if exist then
        { model with currentFile = sampleKey }, []
      else
        { model with
            currentFile = sampleKey
            samplesHTML = (createEmptySampleHtml sampleKey) :: model.samplesHTML }
        , []//Cmd.ofPromise fetchMarkdown fileName (fun x -> SetDocHtml (fileName, x)) (fun x -> Error (fileName, string x))
