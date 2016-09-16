// Signature file for parser generated by fsyacc
module VbaParser
type token = 
  | CALL
  | CASE
  | CLOSE
  | CONST
  | DECLARE
  | DEFBOOL
  | DEFBYTE
  | DEFCUR
  | DEFDATE
  | DEFDBL
  | DEFINT
  | DEFLNG
  | DEFLNGLG
  | DEFLNGPTR
  | DEFOBJ
  | DEFSNG
  | DEFSTR
  | DEFVAR
  | DIM
  | DO
  | ELSE
  | ELSEIF
  | END
  | ENDIF
  | ENUM
  | ERASE
  | EVENT
  | EXIT
  | FOR
  | FRIEND
  | FUNCTION
  | GET
  | GLOBAL
  | GOSUB
  | GOTO
  | IF
  | IMPLEMENTS
  | INPUT
  | LET
  | LOCK
  | LOOP
  | LSET
  | NEXT
  | ON
  | OPEN
  | OPTION
  | PRINT
  | PRIVATE
  | PUBLIC
  | PUT
  | RAISEEVENT
  | REDIM
  | RESUME
  | RETURN
  | RSET
  | SEEK
  | SELECT
  | SET
  | STATIC
  | STOP
  | SUB
  | UNLOCK
  | WEND
  | WHILE
  | WITH
  | WRITE
  | REM
  | ANY
  | AS
  | BYREF
  | BYVAL
  | EACH
  | IN
  | SHARED
  | UNTIL
  | WITHEVENTS
  | OPTIONAL
  | PARAMARRAY
  | PRESERVE
  | SPC
  | TAB
  | THEN
  | TO
  | ADDRESSOF
  | AND
  | EQV
  | IMP
  | IS
  | LIKE
  | NEW
  | MOD
  | NOT
  | OR
  | TYPEOF
  | XOR
  | EXPLICIT
  | COMPARE
  | BINARY
  | TEXT
  | BASE
  | PRIVATEMODULE
  | EOF
  | LPAREN
  | RPAREN
  | COMMA
  | ENDSUB
  | EOS
  | DIGIT of (System.Int32)
  | INT of (System.Int32)
  | TYPE of (string)
  | ID of (string)
type tokenId = 
    | TOKEN_CALL
    | TOKEN_CASE
    | TOKEN_CLOSE
    | TOKEN_CONST
    | TOKEN_DECLARE
    | TOKEN_DEFBOOL
    | TOKEN_DEFBYTE
    | TOKEN_DEFCUR
    | TOKEN_DEFDATE
    | TOKEN_DEFDBL
    | TOKEN_DEFINT
    | TOKEN_DEFLNG
    | TOKEN_DEFLNGLG
    | TOKEN_DEFLNGPTR
    | TOKEN_DEFOBJ
    | TOKEN_DEFSNG
    | TOKEN_DEFSTR
    | TOKEN_DEFVAR
    | TOKEN_DIM
    | TOKEN_DO
    | TOKEN_ELSE
    | TOKEN_ELSEIF
    | TOKEN_END
    | TOKEN_ENDIF
    | TOKEN_ENUM
    | TOKEN_ERASE
    | TOKEN_EVENT
    | TOKEN_EXIT
    | TOKEN_FOR
    | TOKEN_FRIEND
    | TOKEN_FUNCTION
    | TOKEN_GET
    | TOKEN_GLOBAL
    | TOKEN_GOSUB
    | TOKEN_GOTO
    | TOKEN_IF
    | TOKEN_IMPLEMENTS
    | TOKEN_INPUT
    | TOKEN_LET
    | TOKEN_LOCK
    | TOKEN_LOOP
    | TOKEN_LSET
    | TOKEN_NEXT
    | TOKEN_ON
    | TOKEN_OPEN
    | TOKEN_OPTION
    | TOKEN_PRINT
    | TOKEN_PRIVATE
    | TOKEN_PUBLIC
    | TOKEN_PUT
    | TOKEN_RAISEEVENT
    | TOKEN_REDIM
    | TOKEN_RESUME
    | TOKEN_RETURN
    | TOKEN_RSET
    | TOKEN_SEEK
    | TOKEN_SELECT
    | TOKEN_SET
    | TOKEN_STATIC
    | TOKEN_STOP
    | TOKEN_SUB
    | TOKEN_UNLOCK
    | TOKEN_WEND
    | TOKEN_WHILE
    | TOKEN_WITH
    | TOKEN_WRITE
    | TOKEN_REM
    | TOKEN_ANY
    | TOKEN_AS
    | TOKEN_BYREF
    | TOKEN_BYVAL
    | TOKEN_EACH
    | TOKEN_IN
    | TOKEN_SHARED
    | TOKEN_UNTIL
    | TOKEN_WITHEVENTS
    | TOKEN_OPTIONAL
    | TOKEN_PARAMARRAY
    | TOKEN_PRESERVE
    | TOKEN_SPC
    | TOKEN_TAB
    | TOKEN_THEN
    | TOKEN_TO
    | TOKEN_ADDRESSOF
    | TOKEN_AND
    | TOKEN_EQV
    | TOKEN_IMP
    | TOKEN_IS
    | TOKEN_LIKE
    | TOKEN_NEW
    | TOKEN_MOD
    | TOKEN_NOT
    | TOKEN_OR
    | TOKEN_TYPEOF
    | TOKEN_XOR
    | TOKEN_EXPLICIT
    | TOKEN_COMPARE
    | TOKEN_BINARY
    | TOKEN_TEXT
    | TOKEN_BASE
    | TOKEN_PRIVATEMODULE
    | TOKEN_EOF
    | TOKEN_LPAREN
    | TOKEN_RPAREN
    | TOKEN_COMMA
    | TOKEN_ENDSUB
    | TOKEN_EOS
    | TOKEN_DIGIT
    | TOKEN_INT
    | TOKEN_TYPE
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_Prog
    | NONTERM_Stmt
    | NONTERM_StmtList
    | NONTERM_optionClause
    | NONTERM_compareType
    | NONTERM_subProcedureList
    | NONTERM_subProcedure
    | NONTERM_subDeclaration
    | NONTERM_procedureParameters
    | NONTERM_positionalParam
    | NONTERM_parameterType
    | NONTERM_parameterArrayDesignator
    | NONTERM_parameterMechanic
    | NONTERM_procedureStatic
    | NONTERM_procedureScope
    | NONTERM_Id
    | NONTERM_Type
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> (Statements.Prog) 
