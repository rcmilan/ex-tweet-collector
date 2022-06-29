open FSharp.Data.Toolbox.Twitter

open System.Text.Json
open System.Text.Json.Serialization

let jsonOutput obj =
    let options = JsonSerializerOptions()
    options.Converters.Add(JsonFSharpConverter())

    JsonSerializer.Serialize(obj, options)

let key = ""
let secret = ""

let twitter = Twitter.AuthenticateAppOnly(key, secret)
//let tweets = twitter.Search.Tweets("#microsoft", count=1000)

//// Searching for tweets
//for status in tweets.Statuses do
//  printfn "@%s: %s" status.User.ScreenName status.Text

// Display timeline
twitter.Timelines.Timeline("microsoft") |> jsonOutput |> printfn "%A"