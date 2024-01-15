using NLog;

namespace Wordle.Code
{
    public class RandomWordSource : IWordSource
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        Random random = new Random();

        private IList<string> words;

        public RandomWordSource(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File not found", filename);
            }

            Log.Debug("Created word source from " + filename);

            this.words = File.ReadAllLines(filename);
        }

        public string GetWord()
        {
            return words[random.Next(words.Count)];
        }

        public bool IsValidWord(string word)
        {
            return words.Contains(word.ToUpperInvariant());
        }
    }
}
