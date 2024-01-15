namespace Wordle.Code
{
    public class Game
    {
        private IWordSource wordSource;

        public string Word { get; }

        private int turn = 0;

        public Game(IWordSource wordSource)
        {
            this.wordSource = wordSource;
            this.Word = wordSource.GetWord();
        }

        public GuessResult Guess(string guess)
        {
            if (turn == 6)
            {
                throw new InvalidOperationException("Cannot guess: Out of turns");
            }

            guess = guess.ToUpperInvariant();

            if (string.IsNullOrWhiteSpace(guess) || guess.Length != 5 || !guess.All(l => char.IsLetter(l)))
            {
                throw new ArgumentOutOfRangeException(nameof(guess), "Must be a five letter word");
            }

            if (!this.wordSource.IsValidWord(guess))
            {
                throw new ArgumentException("Not a valid word");
            }

            turn++;
            return new GuessResult(this.Word, guess);
        }
    }
}