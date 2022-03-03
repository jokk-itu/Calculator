module Core.Absyn

type expr =
    | CstI of int
    | Prim of string * expr * expr
    | Conditional of expr * expr * expr