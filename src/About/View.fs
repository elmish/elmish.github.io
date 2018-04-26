module About.View

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global

let markdownText =
  "
# About

This app was created with:

- [F#](http://fsharp.org/) a mature, open source, cross-platform, functional-first programming language.
- [Fable](http://fable.io/) F# to Javascript transpiler.
- [Elmish](https://github.com/elmish/elmish) Elm-like abstractions for F# applications targeting Fable.
- [React](https://facebook.github.io/react/) declarative views library for building user interfaces.
- [Bulma](http://bulma.io/) a modern CSS framework based on Flexbox.
- [Marked](https://github.com/chjj/marked) a markdown parser and compiler.
- [FAKE](https://fake.build/) F# make.
  "

let root =
  div
    [ ClassName "content"
      DangerouslySetInnerHTML { __html = Marked.Globals.marked.parse(markdownText) } ]
    [ ]
