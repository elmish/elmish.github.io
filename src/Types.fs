module App.Types

open Global

type Msg =
  | NoOp
  | SampleViewerMsg of Sample.Viewer.Types.Msg

type Model = {
    currentPage: Page
    sampleViewer: Sample.Viewer.Types.Model
  }
