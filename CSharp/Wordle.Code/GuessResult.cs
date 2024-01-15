namespace Wordle.Code
{
    public class GuessResult
    {
        private string word;

        private string guess;

        public bool IsCorrectWord => this.word == this.guess;

        public LetterResult this[int i]
        {
            get
            {
                if (i < 0 || i > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(i), "Index out of range");
                }

                return GetResult(i);
            }
        }

        public GuessResult(string word, string guess)
        {
            if (!IsValidWord(word))
            {
                throw new ArgumentException("Must be a five letter word", nameof(word));
            }

            if (!IsValidWord(guess))
            {
                throw new ArgumentException("Must be a five letter word", nameof(guess));
            }

            this.word = word.ToUpperInvariant();
            this.guess = guess.ToUpperInvariant();
        }

        private bool IsValidWord(string word)
        {
            return !string.IsNullOrWhiteSpace(word) && word.Length == 5 && word.All(c => char.IsLetter(c));
        }

        private LetterResult GetResult(int i)
        {
            if (guess[i] == word[i])
            {
                return LetterResult.Correct;
            }

            if (word.Contains(guess[i]))
            {
                return LetterResult.InWord;
            }

            return LetterResult.Incorrect;
        }
    }
}
