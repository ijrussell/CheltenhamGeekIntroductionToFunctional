// Logging monad

let log p = printfn "expression is %A" p

let loggedWorkflow = 
    let x = 42
    log x
    let y = 43
    log y
    let z = x + y
    log z
    //return
    z

type LoggingBuilder() =
    let log p = printfn "expression is %A" p

    member this.Bind(x, f) = 
        log x
        f x

    member this.Return(x) = 
        x

let logger = new LoggingBuilder()

let loggedWorkflow2 = 
    logger
        {
        let! x = 42
        let! y = 43
        let! z = x + y
        return z
        }

// Divide by zero

let divideBy bottom top =
    if bottom = 0
    then None
    else Some(top/bottom)

let divideByWorkflow init x y z = 
    let a = init |> divideBy x
    match a with
    | None -> None  // give up
    | Some a' ->    // keep going
        let b = a' |> divideBy y
        match b with
        | None -> None  // give up
        | Some b' ->    // keep going
            let c = b' |> divideBy z
            match c with
            | None -> None  // give up
            | Some c' ->    // keep going
                //return 
                Some c'

let good = divideByWorkflow 12 3 2 1
let bad = divideByWorkflow 12 3 0 1

type MaybeBuilder() =

    member this.Bind(x, f) = 
        match x with
        | None -> None
        | Some a -> f a

    member this.Return(x) = 
        Some x
   
let maybe = new MaybeBuilder()

let divideByWorkflow2 init x y z = 
    maybe 
        {
        let! a = init |> divideBy x
        let! b = a |> divideBy y
        let! c = b |> divideBy z
        return c
        }    

let good2 = divideByWorkflow2 12 3 2 1
let bad2 = divideByWorkflow2 12 3 0 1
