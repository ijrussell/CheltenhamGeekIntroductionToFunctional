let addNum name = name + "1"
let addSpecial name = name + "*"
let cap (name:string) =
    string(name.[0]).ToUpper() + name.[1..name.Length-1]

let uniqueUserName = cap >> addNum >> addSpecial

uniqueUserName "prince"

"prince" |> cap |> addNum |> addSpecial

let uniqueUserName2 name = 
    name 
    |> cap 
    |> addNum 
    |> addSpecial

uniqueUserName2 "prince"

