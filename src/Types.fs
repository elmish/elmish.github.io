module App.Types

open Global

type Msg =
  | NoOp
  | DocViewerMsg of Doc.Viewer.Types.Msg
  | SampleViewerMsg of Sample.Viewer.Types.Msg

type Model = {
    currentPage: Page
    docViewer: Doc.Viewer.Types.Model
    sampleViewer: Sample.Viewer.Types.Model
  }
