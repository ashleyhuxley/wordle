namespace Wordle.Code
{
    public interface IWordSource
    {
        string GetWord();

        bool IsValidWord(string word);
    }
}
