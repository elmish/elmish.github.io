module Sample.Index.Types

open Global

type SampleUrl =
  { url: string
    height: int }

let defaultSampleUrl =
  { url = ""
    height = 300 }

type SampleInfo =
  { title: string
    description: string
    url: SampleUrl }

type Sample =
  | Tile of SampleInfo
  | Placeholder

type SectionInfo =
  { title: string
    samples: SampleInfo list }
