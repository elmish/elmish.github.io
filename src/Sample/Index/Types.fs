module Sample.Index.Types

open Global

type SampleReference =
  { demoUrl: string
    title: string
    description: string
    sourceUrl: string
    height: int }

type SectionInfo =
  { title: string
    samples: SampleReference list }

type Model =
  { index: SectionInfo list }
