open System
open FSharp.Text.Lexing
open Lexer
open Parser
open Core.Expr

let evaluate (input:string) =
  let lexbuf = LexBuffer<char>.FromString input
  let output = Parser.parse Lexer.tokenize lexbuf
  string (eval output)

[<EntryPoint>]
let main argv =

    printfn "Press Ctrl+C to Exit"

    while true do
        printf "> "
        let input = Console.ReadLine()
        try
            let result = evaluate input
            printfn $"%s{result}"
        with ex -> printfn $"%s{ex.ToString()}"

    0