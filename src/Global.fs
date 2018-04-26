module Global

open Fable.Core
open Fable.Import

type Page =
  | About
  | Docs
  | Samples of string option

let toHash page =
  match page with
  | About -> "#about"
  | Docs ->
      "#docs"
  | Samples (Some sampleKey) ->
       sprintf "#samples/%s" sampleKey
  | Samples _ ->
      "#samples"

[<Pojo>]
type DangerousInnerHtml =
  { __html : string }

#if DEV
let rawUrl = sprintf "http://%s" Browser.location.host
#else
let rawUrl = "https://raw.githubusercontent.com/elmish/elmish.github.io/master/"
#endif

let createDocFilesDirectoryURL fileName =
  sprintf "%s/docs/%s.md" rawUrl fileName
