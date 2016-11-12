module ParseTests

open vbacop
open Statements
open NUnit.Framework
open FsUnit

let doParse s = 
  let lexbuf = Microsoft.FSharp.Text.Lexing.LexBuffer<_>.FromString s
  let result = VbaParser.start VbaLexer.tokenize lexbuf
  printf "%A" result
  result


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

  [<Test>]
  member x.``Test static 2d array declaration`` ()=
                  doParse "Dim arr(1 to 5, 10) as String
                  " |> should equal { Statements=[ModuleDeclarationList({Scope=PrivateModuleScope;Shared=false;
                                                                         Declarations=[
                                                                                        { 
                                                                                           WithEvents=false;
                                                                                           Declaration=ArrayVariableDeclaration(
                                                                                                                                { 
                                                                                                                                  Name=UntypedName("arr"); 
                                                                                                                                  Array=StaticArrayDeclaration([
                                                                                                                                                                {LowerBound=Some 1; UpperBound=5};
                                                                                                                                                                {LowerBound=None; UpperBound=10};
                                                                                                                                                               ], (Some (Type("String"))))
                                                                                                                                })}

                                                                                      ]})]; SubProcedures=[] }


  [<Test>]
  member x.``Test Module Dim`` ()=
    doParse "Private Shared name() as Integer
    " |> should equal { 
                        Statements = [ ModuleDeclarationList(
                                                              { 
                                                                Scope=PrivateModuleScope; 
                                                                Shared=true; 
                                                                Declarations=
                                                                [
                                                                  { 
                                                                    Declaration=ArrayVariableDeclaration({ Name=UntypedName("name"); Array=DynamicArrayDeclaration(Some (Type("Integer"))) }); 
                                                                    WithEvents=false
                                                                  }
                                                                ] 
                                                              }
                                                            )
                                     ]; SubProcedures=[] }

  [<Test>]
  member x.``Test Module Dim Double`` ()=
    doParse "Private Shared name() as Integer, name2 as String
    " |> should equal { 
                        Statements = [ ModuleDeclarationList(
                                                              { 
                                                                Scope=PrivateModuleScope; 
                                                                Shared=true; 
                                                                Declarations=
                                                                [
                                                                  { 
                                                                    Declaration=ArrayVariableDeclaration({ Name=UntypedName("name"); Array=DynamicArrayDeclaration(Some (Type("Integer"))) }); 
                                                                    WithEvents=false
                                                                  };
                                                                  { 
                                                                    Declaration=NormalVariableDeclaration({ Name=UntypedName("name2"); Type=Some(Type("String")) }); 
                                                                    WithEvents=false
                                                                  }

                                                                ] 
                                                              }
                                                            )
                                     ]; SubProcedures=[] }
