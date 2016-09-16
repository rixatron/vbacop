// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing

// Directories
let buildDir  = "./build/"
let deployDir = "./deploy/"
let testDir   = "./test/"


// Filesets
let appReferences  =
    !! "/**/*.csproj"
    ++ "/**/*.fsproj"

// version info
let version = "0.1"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; deployDir; testDir]
)

Target "BuildApp" (fun _ ->
    // compile all projects below src/app/
    MSBuildDebug buildDir "Build" appReferences
    |> Log "AppBuild-Output: "

    printfn "running chmod..."
    ProcessHelper.Shell.Exec("chmod", "u+x " + System.IO.Path.Combine(buildDir, "vbacop.exe"),null) |> ignore
)

Target "BuildTest" (fun _ -> 
        !! "src/test/*.fsproj"
          |> MSBuildDebug testDir "Build"
          |> Log "TestBuild-Output: ")

Target "Test" (fun _ -> 
        !! (testDir + "/*.tests.dll")
           |> NUnit3 (fun p -> 
                    { p with 
                            ToolPath = "packages/NUnit.ConsoleRunner/tools/nunit3-console.exe"; }))

Target "Deploy" (fun _ ->
    !! (buildDir + "/**/*.*")
    -- "*.zip"
    |> Zip buildDir (deployDir + "ApplicationName." + version + ".zip")
)

// Build order
"Clean"
  ==> "BuildApp"
  ==> "Deploy"

"Clean" 
  ==> "BuildTest" 
  ==> "Test"

// start build
RunTargetOrDefault "BuildApp"
