using Wordle.Code;
using System.Drawing;

namespace Wordle.TextUi
{
    public class GameBoard
    {
        private Keyboard keyboard;

        private WordBoard board;

        private Dictionary<char, LetterResult> letterCache;

        private readonly IWordSource wordSource;

        public GameBoard(IWordSource wordSource)
        {
            this.wordSource = wordSource;

            this.letterCache = new Dictionary<char, LetterResult>();

            this.keyboard = new Keyboard(c => this.letterCache[char.ToLowerInvariant(c)]);
            board = new WordBoard();
        }

        private void InitializeLetterCache()
        {
            this.letterCache.Clear();
            for (char i = 'a'; i <= 'z'; i++)
            {
                this.letterCache.Add(i, LetterResult.NotUsed);
            }


        }

        public void Run()
        {
            while(true)
            {
                PlayGame();
            }
        }

        private void PlayGame()
        {
            Console.Clear();

            InitializeLetterCache();

            board.Render(new Point(3, 3));
            keyboard.Render(new Point(30, 7));

            var game = new Game(this.wordSource);

            for (var go = 0; go < 6; go++)
            {
                bool hasWord = false;
                var letter = 0;
                var currentWord = string.Empty;

                while (!hasWord)
                {
                    Console.SetCursorPosition(5 + (letter * 4), 4 + (go * 2));
                    Console.CursorVisible = letter < 5;

                    var c = Console.ReadKey(true);
                    if (letter < 5 && char.IsLetter(c.KeyChar))
                    {
                        Console.Write(c.KeyChar.ToString().ToUpperInvariant());
                        currentWord += c.KeyChar;
                        letter++;
                    }
                    else if (c.Key == ConsoleKey.Backspace && letter > 0)
                    {
                        letter--;
                        currentWord = currentWord.Substring(0, letter);
                        Console.SetCursorPosition(5 + (letter * 4), 4 + (go * 2));
                        Console.Write(' ');
                    }
                    else if (c.Key == ConsoleKey.Enter && wordSource.IsValidWord(currentWord))
                    {
                        hasWord = true;
                    }
                    else
                    {
                        Console.Beep();
                    }
                }

                var guessResult = game.Guess(currentWord);

                var col = Console.ForegroundColor;
                for (var i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(5 + (i * 4), 4 + (go * 2));
                    Console.ForegroundColor = guessResult[i].ToConsoleFgColor();
                    Console.Write(currentWord.ToUpperInvariant()[i]);

                    this.letterCache[currentWord[i]] = guessResult[i];
                }

                Console.ForegroundColor = col;

                keyboard.Render(new Point(30, 7));

                if (guessResult.IsCorrectWord)
                {
                    break;
                }
            }

            var col1 = Console.ForegroundColor;
            Console.SetCursorPosition(30, 12);
            Console.Write("The word was ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(game.Word);
            Console.ForegroundColor = col1;

            Console.ReadKey();
        }
    }
}
