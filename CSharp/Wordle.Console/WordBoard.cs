using System.Drawing;

namespace Wordle.TextUi
{
    public class WordBoard
    {
        public void Render(Point position)
        {
            string top = "╔═══╦═══╦═══╦═══╦═══╗";
            string row = "║   ║   ║   ║   ║   ║";
            string mid = "╠═══╬═══╬═══╬═══╬═══╣";
            string bot = "╚═══╩═══╩═══╩═══╩═══╝";

            var t = 0;

            Console.SetCursorPosition(position.X, position.Y + t);
            Console.Write(top);

            for (int i = 0; i < 5; i++)
            {
                t++;
                Console.SetCursorPosition(position.X, position.Y + t);
                Console.Write(row);

                t++;
                Console.SetCursorPosition(position.X, position.Y + t);
                Console.Write(mid);
            }

            t++;
            Console.SetCursorPosition(position.X, position.Y + t);
            Console.Write(row);

            t++;
            Console.SetCursorPosition(position.X, position.Y + t);
            Console.Write(bot);
        }
    }
}
