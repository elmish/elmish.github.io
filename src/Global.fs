module Global

open Fable.Core
open Fable.Import

type DocsPages =
  | Index
  | Viewer of string

type SamplesPages =
  | Index
  | Viewer of string option * int option

type Page =
  | Home
  | About
  | Docs of DocsPages
  | Samples of SamplesPages

let toHash page =
  match page with
  | About -> "#about"
  | Home -> "#home"
  | Docs subPage ->
      match subPage with
      | DocsPages.Index -> "#docs"
      | DocsPages.Viewer name -> sprintf "#docs/%s" name
  | Samples subPage ->
      match subPage with
      | SamplesPages.Index -> "#samples"
      | SamplesPages.Viewer (url, height) -> sprintf "#samples?url=%s&height=%i" url.Value height.Value

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
