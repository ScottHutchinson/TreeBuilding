module TreeBuildingTypes

type Record = { RecordId: int; ParentId: int }
type Tree =
    | Branch of int * Tree list
    | Leaf of int

let recordId t =
    match t with
    | Branch (id, _) -> id
    | Leaf id -> id

let isBranch t =
    match t with
    | Branch _ -> true
    | Leaf _ -> false

let children t =
    match t with
    | Branch (_, c) -> c
    | Leaf _ -> []
