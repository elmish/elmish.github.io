module App.Types

open Global

type Msg =
  | HomeMsg of Home.Types.Msg

type Model = {
    currentPage: Page
    home: Home.Types.Model
  }
