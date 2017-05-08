module Sample.Viewer.Types

open Global

type State =
  | Available
  | Pending
  | Error

type SampleHTML =
  { url: string
    html: string
    state: State }

type Model =
  { currentFile: string
    samplesHTML: SampleHTML list }

type Msg =
  | SetSample of string
  | SetSampleHtml of string * string
  | Error of string * string
