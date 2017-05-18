module About.View

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global

let markdownText =
  "
# About

This website is written with:

- [Fable](http://fable.io/) a transpiler F# to Javascript.
- [Elmish](https://github.com/fable-elmish/elmish) an Elm-like abstractions for F# applications targeting Fable.
- [Bulma](http://bulma.io/) a modern CSS framework based on Flexbox.
- [Marked](https://github.com/chjj/marked) a markdown parser and compiler.
  "

let root =
  div
    [ ClassName "content"
      DangerouslySetInnerHTML { __html = Marked.Globals.marked.parse(markdownText) } ]
    [ ]
