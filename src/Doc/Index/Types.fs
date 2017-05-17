module Doc.Index.Types

open Global

type TileInfo =
  { title: string
    description: string
    url: string }

type Tile =
  | Tile of TileInfo
  | Placeholder

type SectionInfo =
  { left: Tile list
    right: Tile list }

  static member Empty =
    { left = []
      right = [] }
