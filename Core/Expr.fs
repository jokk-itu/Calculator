module Core.Expr

open Core.Absyn

let rec eval e : int =
    match e with
    | CstI i -> i
    | Prim("+", x, y) -> eval x + eval y
    | Prim("-", x, y) -> eval x - eval y
    | Prim("/", x, y) -> eval x / eval y
    | Prim("*", x, y) -> eval x * eval y
    | Prim("<>", x, y) -> if eval x <> eval y then 1 else 0
    | Prim("==", x, y) -> if eval x = eval y then 1 else 0
    | Prim("<", x, y) -> if eval x < eval y then 1 else 0
    | Prim(">", x, y) -> if eval x > eval y then 1 else 0
    | Prim("<=", x, y) -> if eval x <= eval y then 1 else 0
    | Prim(">=", x, y) -> if eval x >= eval y then 1 else 0
    | Conditional(x, y, z) -> if eval x = 1 then eval y else eval z
    | _ -> raise (Failure "Unknown Expression")