module vbacop
open Statements
open System

let testParse s = 
  let lexbuf = Microsoft.FSharp.Text.Lexing.LexBuffer<_>.FromString s
  let y = VbaParser.start VbaLexer.tokenize lexbuf
  Console.WriteLine(sprintf "Parsing complete: \r\n %A" y)
  Console.ReadKey(true) |> ignore

let testLex s = 
  let lexbuf = Microsoft.FSharp.Text.Lexing.LexBuffer<_>.FromString s

  while lexbuf.IsPastEndOfStream = false do
    VbaLexer.tokenize lexbuf |> ignore

  Console.WriteLine("(Press any key)")
  Console.ReadKey(true) |> ignore

  

[<EntryPoint>]
let main argv =
//    printfn "%A" argv
//    match argv with
//      | [|x|] -> testString x
//      | _ -> printfn "%s" "Just one quoted string please"
    testParse "Option Explicit
"
    
    0 // return an integer exit code
