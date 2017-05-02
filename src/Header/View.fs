module Header.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global
open Types

let footerLinkItem menuLink currentPage =
  let isCurrentPage =
    match currentPage with
    | Home | About ->
        menuLink.destination = currentPage
    | Docs _ ->
        match menuLink.destination with
        | Docs _ -> true
        | _ -> false
    | Samples _ ->
        match menuLink.destination with
        | Samples _ -> true
        | _ -> false

  li
    [ classList [ "is-active", isCurrentPage ] ]
    [ a
        [ Href (toHash menuLink.destination) ]
        [ str menuLink.text] ]

let footerLinks items currentPage =
    ul
      []
      (items |> List.map(fun x -> footerLinkItem x currentPage))

let footer model =
  div
    [ ClassName "hero-foot" ]
    [ div
        [ ClassName "container" ]
        [ nav
            [ ClassName "tabs is-boxed" ]
            [ footerLinks
                [ { text = "Home"
                    destination = Page.Home }
                  { text = "Docs"
                    destination = Page.Docs None }
                  { text = "Samples"
                    destination = Page.Samples None }
                  { text = "About"
                    destination = Page.About } ]
                model ] ] ]

let root (model: Page) =
    section
      [ ClassName "hero is-primary" ]
      [ div
          [ ClassName "hero-body" ]
          [ div
              [ ClassName "container" ]
              [ div
                  [ ClassName "columns is-vcentered" ]
                  [ div
                      [ ClassName "column" ]
                      [ h1
                          [ ClassName "title" ]
                          [ str "Documentation"]
                        h2
                          [ ClassName "subtitle" ]
                          [ str "Everything you need to create a website using "
                            strong
                              []
                              [ str "Elmish" ] ] ] ] ] ]
        footer model ]
