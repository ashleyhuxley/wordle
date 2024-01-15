using Wordle.Code;

namespace Wordle.TextUi
{
    public static class LetterResultExtensions
    {
        public static ConsoleColor ToConsoleFgColor(this LetterResult result)
        {
            switch (result)
            {
                case LetterResult.Incorrect: return ConsoleColor.Red;
                case LetterResult.Correct: return ConsoleColor.Green;
                case LetterResult.InWord: return ConsoleColor.Cyan;
                default: return ConsoleColor.White;
            }
        }
    }
}
