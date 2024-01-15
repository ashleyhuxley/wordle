using System.Drawing;
using Wordle.Code;

namespace Wordle.TextUi
{
    public class Keyboard
    {
        private string keys = "QWERTYUIOPASDFGHJKLZXCVBNM";

        private Func<char, LetterResult> letterLookup;

        public Keyboard(Func<char, LetterResult> letterLookup)
        {
            this.letterLookup = letterLookup;
        }

        public void Render(Point position)
        {
            var bgcolor = Console.BackgroundColor;
            var fgcolor = Console.ForegroundColor;

            Console.SetCursorPosition(position.X, position.Y);
            for (int i = 0; i < 10; i++)
            {
                var c = keys[i];
                var result = this.letterLookup(c);

                Console.ForegroundColor = result.ToConsoleFgColor();
                Console.Write(c + " ");
            }

            Console.SetCursorPosition(position.X + 1, position.Y + 1);
            for (int i = 10; i < 19; i++)
            {
                var c = keys[i];
                var result = this.letterLookup(c);

                Console.ForegroundColor = result.ToConsoleFgColor();
                Console.Write(c + " ");
            }

            Console.SetCursorPosition(position.X + 3, position.Y + 2);
            for (int i = 19; i < 26; i++)
            {
                var c = keys[i];
                var result = this.letterLookup(c);

                Console.ForegroundColor = result.ToConsoleFgColor();
                Console.Write(c + " ");
            }

            Console.ForegroundColor = fgcolor;
            Console.BackgroundColor = bgcolor;
        }
    }
}
