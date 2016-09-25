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


    [<Test; Sequential>]
     member x.``Test decimal literal intialisation``
               (
                 [<Values("x = 10","x = -10")>]i:string,
                 [<Values(10,-10)>]n:int
               ) =
        let actual = doLex i
        let expected = [ID("x");EQUALS;INT({ Value=n;NumberType=Decimal});EOF]
        compare expected actual

     [<Test; Sequential>]
     member x.``Test octal literal intialisation`` 
               (
                 [<Values("x = &o11","x = &O11", "x = &11", "x = -&11")>]i:string,
                 [<Values(9,9,9,-9)>]n:int
               ) =
        let actual = doLex i
        let expected = [ID("x");EQUALS;INT({ Value=n;NumberType=Octal});EOF]
        compare expected actual

    [<Test>]
     member x.``Test hex literal intialisation`` 
               (
                 [<Values("x = &hFF","x = &hff", "x = &HFF", "x = -&HFF")>]i:string,
                 [<Values(255,255,255,-255)>]n:int
               ) =
        let actual = doLex "x = &hFF" 
        let expected = [ID("x");EQUALS;INT({ Value=255;NumberType=Hexadecimal});EOF]
        compare expected actual


    [<Test; Sequential>]
     member x.``Test float literal intialisation``
               (
                 [<Values("10.","10D2","10.1",".1E2",".1",".1d-2")>]i:string,
                 [<Values(10.,1000,10.1,10,0.1,0.001)>]n:decimal
               ) =
        let actual = doLex i
        let expected = [FLOAT({ Value=n;NumberType=Double});EOF]
        compare expected actual

    member x.DoDateTest (s:string) (d:System.DateTime) =
        let actual = doLex s
        let expected = [DATETIME(d);EOF] 
        compare expected actual

    [<Test>]
    member x.``Test date intialisation dd-mmm-yyyy`` ()=
        x.DoDateTest "#01-Mar-2016#" (new System.DateTime(2016,3,1))

    [<Test>]
    member x.``Test date intialisation dd-mmm-yyyy hh:mm am`` ()=
        x.DoDateTest "#01-Mar-2016 06:15 am#" (new System.DateTime(2016,3,1,6,15,0))

    [<Test>]
    member x.``Test date intialisation dd-mmm-yyyy hh:mm a`` ()=
        x.DoDateTest "#01-Mar-2016 06:15 a#" (new System.DateTime(2016,3,1,6,15,0))

    [<Test>]
    member x.``Test date intialisation dd-mmm-yyyy hh:mm pm`` ()=
        x.DoDateTest "#01-Mar-2016 06:15 pm#" (new System.DateTime(2016,3,1,18,15,0))

    [<Test>]
    member x.``Test date intialisation dd-mmm-yyyy hh:mm p`` ()=
        x.DoDateTest "#01-Mar-2016 06:15 p#" (new System.DateTime(2016,3,1,18,15,0))

    [<Test>]
    member x.``Test time intialisation hh:mm pm`` ()=
        x.DoDateTest "#03:45 am#" (new System.DateTime(1899,12,30,3,45,0))

    [<Test>]
    member x.``Test time intialisation hh.mm pm`` ()=
        x.DoDateTest "#03.45 pm#" (new System.DateTime(1899,12,30,15,45,0))

    [<Test>]
    member x.``Test time intialisation h p`` ()=
        x.DoDateTest "#6 p#" (new System.DateTime(1899,12,30,18,0,0))

    [<Test>]
    member x.``Test time intialisation hh : mm pm`` ()=
        x.DoDateTest "#03 : 45 am#" (new System.DateTime(1899,12,30,3,45,0))

    [<Test>]
    member x.``Test time intialisation hh:mm:ss pm`` ()=
        x.DoDateTest "#03:45:30 am#" (new System.DateTime(1899,12,30,3,45,30))

    [<Test>]
    member x.``Test date intialisation dd,mm,yyyy`` ()=
        x.DoDateTest "#01,03,2016#" (new System.DateTime(2016,1,3))

    [<Test>]
    member x.``Test date intialisation dd,mmmmmm`` ()=
        x.DoDateTest "#01 August#" (new System.DateTime(2016,8,1))

    [<Test;Sequential>]
    member x.``Test basic string`` 
               (
                 [<Values("\"Test String\"","\"Test \"\"String\"\"\"","\"\"")>]i:string,
                 [<Values("Test String", "Test \"String\"", "")>]n:string
               ) =
        let actual = doLex i
        let expected = [STRING(n); EOF]
        compare expected actual
          
