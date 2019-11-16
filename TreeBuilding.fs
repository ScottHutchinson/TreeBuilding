module TreeBuilding

open TreeBuildingTypes

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

let rec build prev acc list =
    match list with
    | [] -> acc |> List.rev
    | r :: rs ->
        if r.ParentId >= r.RecordId then
            failwith "Nodes with invalid parents"
        elif r.RecordId <> prev + 1 then
                failwith "Non-continuous list"
        else
            build r.RecordId (r :: acc) rs

let zeroRecord = { RecordId = 0; ParentId = -1 }
let leafs lst = build 0 [zeroRecord] lst

let rec getNode recordId records =
    let children =
        records
        |> List.filter(fun x -> x.ParentId = recordId)

    match children with
    | [] -> Leaf recordId
    | _ ->
        let childNodes =
            children
            |> List.map(fun x -> getNode x.RecordId records)

        Branch(recordId, childNodes)

let buildTree records =
    let sortedRecords = records |> List.sortBy (fun x -> x.RecordId)
    match sortedRecords with
    | [] -> failwith "Empty input"
    | h :: t ->
        if h.ParentId <> 0 then
            failwith "Root node ParentId is invalid"
        elif h.RecordId <> 0 then
            failwith "Root node RecordId is invalid"
        else
            getNode 0 (leafs t)
