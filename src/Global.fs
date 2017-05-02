module Global

open Fable.Core
open Fable.Import

type Page =
  | Home
  | About
  | Docs of string option
  | Samples of (int * string) option

let toHash page =
  match page with
  | About -> "#about"
  | Home -> "#home"
  | Docs (Some name) ->
      sprintf "#docs/%s" name
  | Docs _ ->
      "#docs"
  | Samples (Some (height,url)) ->
       sprintf "#samples/%i/%s" height url
  | Samples _ ->
      "#samples"

[<Pojo>]
type DangerousInnerHtml =
  { __html : string }

#if DEV
let rawUrl = sprintf "http://%s" Browser.location.host
#else
let rawUrl = "https://raw.githubusercontent.com/fable-elmish/fable-elmish.github.io/master/"
#endif

let createDocFilesDirectoryURL fileName =
  sprintf "%s/docs/%s.md" rawUrl fileName
