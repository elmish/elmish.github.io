module App.Types

open Global

type Msg =
  | NoOp
  | DocsViewerMsg of Docs.Viewer.Types.Msg

type Model = {
    currentPage: Page
    docsViewer: Docs.Viewer.Types.Model
  }
