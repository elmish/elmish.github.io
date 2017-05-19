module App.Types

open Global

type Msg =
  | NoOp

type Model =
  { currentPage: Page
    docs : Doc.Index.Types.Model }
