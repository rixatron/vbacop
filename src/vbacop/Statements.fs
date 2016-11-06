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

type Type = 
 | Type of string
 | AutoType of string

type Name =
  | UntypedName of string
  | TypedName of string * string

type Declaration = string * string

type ModuleDeclarationScope = 
  | PublicModuleScope
  | PrivateModuleScope
  | GlobalModuleScope


type StaticArrayDeclaration =
  {
    LowerBound : int option
    UpperBound : int 
  }

type ArrayDeclaration =
  | StaticArrayDeclaration of StaticArrayDeclaration list * Type option
  | DynamicArrayDeclaration of Type option

type NormalVariableDeclaration = 
  {
    Name : Name
    Type : Type option
  }

type ArrayVariableDeclaration =
  {
    Name : Name
    Array : ArrayDeclaration
  }

type VariableDeclaration =
  | NormalVariableDeclaration of NormalVariableDeclaration
  | ArrayVariableDeclaration of ArrayVariableDeclaration

type ModuleDeclaration =
  {
    Declaration : VariableDeclaration
    WithEvents : bool
  }

type ModuleDeclarationList = 
  {
    Scope : ModuleDeclarationScope
    Shared : bool
    Declarations : ModuleDeclaration list
  }

type GlobalVariableDeclaration = ModuleDeclaration list

type DefRange = DefRange of string * string

type CompareOption =
      | Text
      | Binary

type Option = 
      | Explicit
      | CompareOption of CompareOption
      | Base of int
      | PrivateModule

type ProcedureScope =
      | GlobalProcedureScope
      | PublicProcedureScope
      | PrivateProcedureScope
      | FriendProcedureScope

type VariableScope = 
      | GlobalVariableScope
      | PublicVariableScope
      | PrivateVariableScope

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
  | Declaration of Declaration

type ModuleStatement =
  | Option of Option
  | ModuleDeclaration of ModuleDeclaration
  | ModuleDeclarationList of ModuleDeclarationList

type SubProcedure = 
  {
    Declaration : SubDeclaration
    Statements  : Statement list
  }

type Prog = 
  { 
    Statements : ModuleStatement list
    SubProcedures : SubProcedure list
  }

let getArrayDecl(l,u) =
    match l,u with
      | Some a, None -> { UpperBound = a; LowerBound=None }
      | Some a, Some b -> { LowerBound = Some a; UpperBound=b }
      | _ -> failwith "guess i failed to make invalid states unrepresentable"

let a = fun t -> StaticArrayDeclaration((List.map getArrayDecl []), t) 
let t = fun t -> DynamicArrayDeclaration(t) 
let construct t = StaticArrayDeclaration((List.map getArrayDecl []), t) 
let constrcut2 t = DynamicArrayDeclaration(t) 
