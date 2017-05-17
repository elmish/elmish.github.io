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
      { model with currentPage = page }, []

let init result =
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home }
  model, Cmd.batch [  cmd ]

let update msg model =
  match msg with
  | NoOp -> model, []
