// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using Wordle.Code;
using Wordle.TextUi;

//var keyboard = new Keyboard(k => k == 'F' ? LetterResult.Correct : LetterResult.NotUsed);
//keyboard.Render(new System.Drawing.Point(10, 5));

var log = NLog.LogManager.GetCurrentClassLogger();
log.Info("Program started");


var wordSource = new RandomWordSource("D:\\Code\\Wordle\\words.txt");
//var board = new GameBoard(wordSource);
//board.Run();

Console.WriteLine("WORDLE");

var game = new Game(wordSource);

for (int go = 0; go < 6; go++)
{
    bool valid = false;
    string? guess = null;
    while (!valid)
    {
        Console.Write(">");
        guess = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(guess) || !wordSource.IsValidWord(guess))
        {
            Console.WriteLine("Not a valid word");
        }
        else
        {
            valid = true;
        }
    }

    GuessResult result = game.Guess(guess);

    var col = Console.BackgroundColor;

    for (int i = 0; i < 5; i++)
    {
        switch (result[i])
        {
            case LetterResult.Incorrect:
                Console.BackgroundColor = ConsoleColor.DarkGray;
                break;
            case LetterResult.InWord:
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                break;
            case LetterResult.Correct:
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                break;
        }

        Console.Write(guess[i]);
    }

    Console.BackgroundColor = col;
    Console.WriteLine();
    if (result.IsCorrectWord)
    {
        break;
    }
}

Console.WriteLine("The word was: " + game.Word);


