module Sample.Viewer.Types

open Global

type State =
  | Available
  | Pending
  | Error

type DocHTML =
  { fileName: string
    html: string
    state: State }

type Model =
  { currentFile: string
    docsHTML: DocHTML list }

type Msg =
  | SetDoc of string
  | SetDocHtml of string * string
  | Error of string * string
