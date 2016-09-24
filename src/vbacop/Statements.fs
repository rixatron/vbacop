module Statements
open Microsoft.FSharp.Collections

type IntNumberType = 
  | Decimal
  | Hexadecimal
  | Octal

type FloatNumberType = 
  | Single
  | Double
  | Currency

type IntValue =
  {
    Value : int
    NumberType : IntNumberType
  }

type FloatValue =
  {
    Value : decimal
    NumberType : FloatNumberType
  }

type Value = 
 | Int of IntValue
 | Float of FloatValue
 | DateTimeValue of System.DateTime

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


