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
    // | Sample _ ->
    //     match menuLink.Route with
    //     | Sample  _ -> true
    //     | _ -> false
    // | Docs _ ->
    //     match menuLink.Route with
    //     | Docs _ -> true
    //     | _ -> false

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
                          [ ClassName "subtitle"
                            DangerouslySetInnerHTML {
                              __html = "Everything you need to create a website using <strong>Elmish<strong>"
                            }
                          ]
                          [] ] ] ] ]
        footer model ]
