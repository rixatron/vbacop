module LexTests

open vbacop
open Statements
open NUnit.Framework
open FsUnit
open VbaParser
open VbaLexer

let doLex s = 
  let lexbuf = Microsoft.FSharp.Text.Lexing.LexBuffer<_>.FromString s
  let rec getList b l =
      if lexbuf.IsPastEndOfStream then
        List.rev l
      else
        let t = VbaLexer.tokenize b 
        getList b (t :: l)
  getList lexbuf []

[<TestFixture>]
type LexerTests ()= 

    let compare expected actual =
        printfn "Expected %A" expected
        printfn "Actual %A" actual
        actual |> should equal expected


    [<Test>]
     member x.``Test decimal literal intialisation`` () =
        let actual = doLex "x = 10" 
        let expected = [ID("x");EQUALS;INT({ Value=10;NumberType=Decimal});EOF]
        compare expected actual

     [<Test>]
     member x.``Test octal literal intialisation`` ([<Values("x = &o11","x = &O11", "x = &11")>]i:string) =
        let actual = doLex i
        let expected = [ID("x");EQUALS;INT({ Value=9;NumberType=Octal});EOF]
        compare expected actual

    [<Test>]
     member x.``Test hex literal intialisation`` () =
        let actual = doLex "x = &hFF" 
        let expected = [ID("x");EQUALS;INT({ Value=255;NumberType=Hexadecimal});EOF]
        compare expected actual


