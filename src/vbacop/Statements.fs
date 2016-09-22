module Statements
open Microsoft.FSharp.Collections

type NumberType = 
  | Decimal
  | Hexadecimal
  | Octal

type IntValue =
  {
    Value : int
    NumberType : NumberType
  }

type Value = 
 | Int of IntValue

type Type = Type of string

type Declaration = string * string

type CompareOption =
      | Text
      | Binary
type Option = 
      | Explicit
      | CompareOption of CompareOption
      | Base of int
      | PrivateModule

type ProcedureScope =
      | Global
      | Public
      | Private
      | Friend

type ProcedureStatic =
      | Static

type ParameterMechanic =
      | ByVal
      | ByRef

type Parameter =
  {
    Mechanic   : ParameterMechanic option
    IsArray    : bool
    IsOptional : bool
    Type       : Type
    Name       : string
  }
type ProcedureParams = Parameter list 


type SubDeclaration =
  {
     Scope      : ProcedureScope option
     Static     : ProcedureStatic option
     Name       : string
     Parameters : ProcedureParams
  }

type Statement =
  | Option of Option
  | Declaration of Declaration

type SubProcedure = 
  {
    Declaration : SubDeclaration
    Statements  : Statement list
  }

type Prog = 
  { 
    Statements : Statement list
    SubProcedures : SubProcedure list
  }


