module Sample.Index.Types

open Global

type SampleInfo =
  { title: string
    description: string
    sampleKey: string }

type SampleReference =
  { demoUrl: string
    sourceUrl: string
    height: int }

type Sample =
  | Tile of SampleInfo
  | Placeholder

type SectionInfo =
  { title: string
    samples: SampleInfo list }
