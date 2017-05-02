module Sample.Viewer.State

open Elmish
open Fable.PowerPack
open Fable.PowerPack.Fetch
open Types
open Global
open Fable.Import

let init () =
  { currentFile = ""
    docsHTML = [] }, []

let update msg model =
  model, []
