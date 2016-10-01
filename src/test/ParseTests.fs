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

  [<Test>] 
  member x.``Test Single option explcit`` ()=
              doParse "Option Explicit
              " |> should equal {  Statements = [(Option(Explicit))]; SubProcedures=[] }

  [<Test>] 
  member x.``Test Single option compare text`` ()=
              doParse "Option Compare Text
              " |> should equal {  Statements = [(Option(CompareOption(Text)))]; SubProcedures=[] }

  [<Test>] 
  member x.``Test Single option compare binary`` ()=
              doParse "Option Compare Binary
              " |> should equal {  Statements = [(Option(CompareOption(Binary)))]; SubProcedures=[] }

  [<Test>] 
  member x.``Test Single option base`` ()=
              doParse "Option Base 2
              " |> should equal {  Statements = [(Option(Base(2)))]; SubProcedures=[] }

  [<Test>] 
  member x.``Test Single option private`` ()=
                  doParse "Option Private Module
                  " |> should equal {  Statements = [(Option(PrivateModule))]; SubProcedures=[] }
