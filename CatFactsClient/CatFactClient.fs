namespace CatFacts

open System.Net.Http
open Newtonsoft.Json

module CatFactClient =
    type CatFact = {
        User: string;
        Text: string;
        Type: string;
    }

    let getRandomFactJson animalType amount =
        let url = sprintf "https://cat-fact.herokuapp.com/facts/random?animal_type=%s&amount=%d" animalType amount
        use client = new HttpClient()
        use response = client.GetAsync url |> Async.AwaitTask |> Async.RunSynchronously
        let content = response.Content.ReadAsStringAsync() |> Async.AwaitTask |> Async.RunSynchronously
        content

    let extractFact jsonFact =
        try
            let parsed = JsonConvert.DeserializeObject<CatFact>(jsonFact)
            parsed.Text
        with
           | ex -> eprintf "%s\n" ex.Message; "Cat Fact Failure!"


    let getCatFact () =
        getRandomFactJson "cat" 1
        |> extractFact