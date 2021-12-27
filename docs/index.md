---
layout: navbar-only
---


<div class="container mt-5" data-disable-copy-button="true">
    <!-- <section class="section">
        <h2 class="title is-2 has-text-primary has-text-centered">
            Thoth.Json
        </h2>
        <p class="content is-size-5 has-text-centered">
            JSON the simple and safe way
        </p>
    </section> -->
    <section class="section selling-points">


<div class="selling-point">
    <div class="selling-point-header">
        <h4 class="title has-text-primary">
            Elmish
        </h4>
        <div class="content is-size-5 mb-3">

Elmish define a core abstractions allow you to build Fable application followng the **model view update** style of architecture.
        </div>
        <a href="https://elmish.github.io/elmish/">
            Learn more →
        </a>
    </div>
    <div class="selling-point-showcase content">

```fs
type Model =
    { Value : string }

type Msg =
    | ChangeValue of string

let init () =
    { Value = "" }, Cmd.none

let update (msg:Msg) (model:Model) =
    match msg with
    | ChangeValue newValue ->
        { model with Value = newValue }, Cmd.none

let view model dispatch =
    Html.div [
        Html.input [
            prop.value model.Value
            prop.onChange (fun value ->
                value |> ChangeValue |> dispatch
            )
        ]

        Html.span [
            prop.text $"Hello, %s{model.Value}!"
        ]
    ]
```
</div>
</div>


<div class="selling-point">
    <div class="selling-point-header">
        <h4 class="title has-text-primary">
            Elmish.React
        </h4>
        <div class="content is-size-5 mb-3">

Build **React** and **ReactNative** apps with elmish.
        </div>
        <a href="https://elmish.github.io/react/">
            Learn more →
        </a>
    </div>
    <div class="selling-point-showcase content">

```fs
let view model dispatch =
    Html.div [
        Html.input [
            prop.value model.Value
            prop.onChange (fun value ->
                value |> ChangeValue |> dispatch
            )
        ]

        Html.span [
            prop.text $"Hello, %s{model.Value}!"
        ]
    ]
```
</div>
</div>


<div class="selling-point">
    <div class="selling-point-header">
        <h4 class="title has-text-primary">
            Elmish.Browser
        </h4>
        <div class="content is-size-5 mb-3">

Implements **routing** and **navigation** for elmish apps targeting browser (SPAs).
        </div>
        <a href="https://elmish.github.io/browser/">
            Learn more →
        </a>
    </div>
    <div class="selling-point-showcase content">

```fs
// Make the program support navigation
open Elmish.Navigation

Program.mkProgram init update view
|> Program.toNavigable parser urlUpdate
|> Program.run

// Usage

let update model msg =
    match msg with
    | GoToTutorial ->
        // Built-in function to manipulate location
        model, Navigation.newUrl "tutorial"
```
</div>
</div>


</div>

<hr>

<section class="section mb-6">

<h2 class="title has-text-centered mb-6">Developper experience</h2>


<div class="feature-grid container">
    <div class="feature-header">
    </div>
    <div class="feature-grid-features">
        <div>
            <a href="https://elmish.github.io/hmr/">
                <span class="icon is-large">
                    <i class="fas fa-forward fa-2x"></i>
                </span>
                <h3>Stateful hot reload</h3>
                <p>
                Elmish supports <strong>Hot Module Replacement</strong  > (HMR) allowing you to quickly change your code without losing your state.
                </p>
            </a>
        </div>
        <div>
            <a href="https://elmish.github.io/debugger/">
                <span class="icon is-large">
                    <i class="fas fa-bug fa-2x"></i>
                </span>
                <h3>Debugger</h3>
                <p>
                Observe the state of your application in real time.
                </p>
            </a>
        </div>
    </div>
</div>

</section>
