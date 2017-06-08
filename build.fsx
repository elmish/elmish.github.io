// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"

open System
open System.IO
open Fake
open Fake.NpmHelper
open Fake.Git


let yarn = 
    if EnvironmentHelper.isWindows then "yarn.cmd" else "yarn"
    |> ProcessHelper.tryFindFileOnPath
    |> function
       | Some yarn -> yarn
       | ex -> failwith ( sprintf "yarn not found (%A)\n" ex )

let gitName = "fable-elmish.github.io"
let gitOwner = "fable-elmish"
let gitHome = sprintf "https://github.com/%s" gitOwner

let dotnetcliVersion = "1.0.1"
let mutable dotnetExePath = "dotnet"

let runDotnet workingDir =
    DotNetCli.RunCommand (fun p -> { p with ToolPath = dotnetExePath
                                            WorkingDir = workingDir } )

Target "InstallDotNetCore" (fun _ ->
   dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

Target "Clean" (fun _ ->
    CleanDir "build"
)

Target "Install" (fun _ ->
    Npm (fun p ->
        { p with
            NpmFilePath = yarn
            Command = Install Standard
        })
    runDotnet "." "restore"
)

Target "Build" (fun _ ->
    runDotnet "." "fable npm-run build"
)

Target "Watch" (fun _ ->
    runDotnet "." "fable npm-run start"
)

// --------------------------------------------------------------------------------------
// Release Scripts

Target "ReleaseSite" (fun _ ->
    let tempDocsDir = "temp/master"
    CleanDir tempDocsDir
    Repository.cloneSingleBranch "" (gitHome + "/" + gitName + ".git") "master" tempDocsDir

    CopyRecursive "build" tempDocsDir true |> tracefn "%A"

    StageAll tempDocsDir
    Git.Commit.Commit tempDocsDir (sprintf "Update generated site")
    Branches.push tempDocsDir
)

Target "Publish" DoNothing

// Build order
"Clean"
  ==> "InstallDotNetCore"
  ==> "Install"
  ==> "Build"

"Clean"
  ==> "InstallDotNetCore"
  ==> "Install"
  ==> "Watch"
  
"Publish"
  <== [ "Build"
        "ReleaseSite" ]
  
  
// start build
RunTargetOrDefault "Build"
