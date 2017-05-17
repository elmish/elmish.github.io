module Home.View

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global

let markdownText =
  "
# Fable-elmish samples

Fable-elmish is a set of tools for building modern web applications inspired by the [elm architecture](http://guide.elm-lang.org/architecture/index.html).

Fable-elmish uses [Fable](http://fable.io/) which allows you to write your code using F# and compile in JavaScript.

Hopefully the samples here show you how to get started and gives you some inspiration about how to build your application using Fable-elmish.

You can also contribute more examples by sending us a pull request.
  "

let root =
  div
    [ ClassName "content"
      DangerouslySetInnerHTML { __html = Marked.Globals.marked.parse(markdownText) } ]
    [ ]
