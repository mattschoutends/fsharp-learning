namespace CatFacts

open System.Net.Http
open FSharp.Data
open FSharp.Data.JsonExtensions

module CatFactClient =

    let getRandomFactJson animalType amount =
        let url = sprintf "https://cat-fact.herokuapp.com/facts/random?animal_type=%s&amount=%d" animalType amount
        use client = new HttpClient()
        use response = client.GetAsync url |> Async.AwaitTask |> Async.RunSynchronously
        let content = response.Content.ReadAsStringAsync() |> Async.AwaitTask |> Async.RunSynchronously
        content

    let extractFact jsonFact =
        let parsed = JsonValue.Parse jsonFact
        let text = parsed?text
        text.AsString()


    let getCatFact () =
        getRandomFactJson "cat" 1
        |> extractFact