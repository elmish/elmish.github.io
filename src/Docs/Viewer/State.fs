module Docs.Viewer.State

open Elmish
open Fable.PowerPack
open Fable.PowerPack.Fetch
open Types
open Global
open Fable.Import

let init () =
  { currentFile = ""
    docsHTML = [] }, []

let createEmptyDocHtml fileName =
  { fileName = fileName
    html = ""
    state = Pending }

let fetchMarkdown fileName =
  promise {
    let! res = fetch (createDocFilesDirectoryURL fileName) []
    let! txt = res.text()
    return Marked.Globals.marked.parse txt
  }

let update msg model =
  match msg with
  | SetDoc fileName ->
      // Fetch the markdown content only if unkown doc entry
      let exist =
        model.docsHTML
        |> List.exists(fun x -> x.fileName = fileName )

      if exist then
        { model with currentFile = fileName }, []
      else
        { model with
            currentFile = fileName
            docsHTML = (createEmptyDocHtml fileName) :: model.docsHTML }
        , Cmd.ofPromise fetchMarkdown fileName (fun x -> SetDocHtml (fileName, x)) (fun x -> Error (fileName, string x))
  | SetDocHtml (fileName, content) ->
      let docs =
        model.docsHTML
        |> List.map(fun doc ->
          if doc.fileName = fileName then
            { doc with
                html = content
                state = Available }
          else
            doc
        )
      { model with docsHTML = docs }, []
  | Error (fileName, error) ->
      Browser.console.error error
      let docs =
        model.docsHTML
        |> List.map(fun doc ->
          if doc.fileName = fileName then
            { doc with state = State.Error }
          else
            doc
        )
      { model with docsHTML = docs }, []
