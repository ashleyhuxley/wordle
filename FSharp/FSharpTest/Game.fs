module Game  

    open System
    open System.Linq

    open WordSource
    open Result

    type Game(source: RandomWordSource) =
        let source = source
        let word = source.GetWord()
        let mutable turn: int = 0

        member this.Turn 
            with get() = turn
            and private set(value) =
                turn <- value

        member this.Guess(guess: string) =
            if turn = 6 then failwith "Out of turns"
            let actualGuess = guess.ToUpperInvariant()

            if String.IsNullOrWhiteSpace(guess) || guess.Length <> 5 || not (guess.All(fun x -> Char.IsLetter(x))) then failwith "Invalid word"
            if not (source.IsValid(guess)) then failwith "Not a valid word"

            this.Turn <- turn + 1
            GuessResult(word, guess)