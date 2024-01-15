module Result

    open System
    open System.Linq

    type LetterResult =
     | Correct
     | Incorrect
     | InWord

    type GuessResult(word: string, guess: string) =
        do
            if not (GuessResult.IsValidWord(word)) then failwith "word is not a valid word"
            if not (GuessResult.IsValidWord(guess)) then failwith "guess is not a valid word"
        let word = word
        let guess = guess
        
        static member IsValidWord(word: string) = 
            not (String.IsNullOrWhiteSpace(word)) && word.Length = 5 && word.All(fun c -> Char.IsLetter(c))

        member this.GetResult(i: int) =
            if guess[i] = word[i] then Correct
            elif word.Contains(guess[i]) then InWord
            else Incorrect