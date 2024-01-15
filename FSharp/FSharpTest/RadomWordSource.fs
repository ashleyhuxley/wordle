module WordSource
    
    open System
    open System.IO
    open System.Linq
    
    type RandomWordSource(filename: string) =
        let words = File.ReadAllLines(filename)
        let random = Random()

        member this.GetWord() = words[random.Next(words.Length)]
        member this.IsValid(word: string) = word.ToUpperInvariant() |> fun(upperWord: string) -> words.Any(fun x -> x = upperWord)