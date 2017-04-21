module Global

open Fable.Core

type Page =
  | Home
  | About

let toHash page =
  match page with
  | About -> "#about"
  | Home -> "#home"

[<Pojo>]
type DangerousInnerHtml =
  { __html : string }
