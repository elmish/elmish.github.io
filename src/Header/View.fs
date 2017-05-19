module Header.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Global
open Types

let footerLinkItem menuLink currentPage =
  let isCurrentPage =
    match currentPage with
    | About | Docs ->
        menuLink.destination = currentPage
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
            [ ClassName "tabs is-boxed is-centered" ]
            [ footerLinks
                [ { text = "Docs"
                    destination = Page.Docs }
                  { text = "Samples"
                    destination = Page.Samples None }
                  { text = "About"
                    destination = Page.About } ]
                model ] ] ]

let root (model: Page) =
    div
      [ ClassName "hero is-primary" ]
      [ div
          [ ClassName "hero-body" ]
          [ div
              [ ClassName "column has-text-centered" ]
              [ div
                  [ ]
                  [ div
                      []
                      [ h2
                          [ ClassName "subtitle" ]
                          [ str "Fable applications following \"model view update\" architecture" ] ] ] ] ]
        footer model ]
