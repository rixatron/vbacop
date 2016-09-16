module ParseTests

open vbacop
open Statements
open NUnit.Framework
open FsUnit

let doParse s = 
  let lexbuf = Microsoft.FSharp.Text.Lexing.LexBuffer<_>.FromString s
  VbaParser.start VbaLexer.tokenize lexbuf

[<TestFixture>]
type ParserTests ()=

  [<Test>] member x.``Test Single option explcit`` ()=
              doParse "Option Explicit
              " |> should equal {  Statements = [(Option(Explicit))]; SubProcedures=[] }



