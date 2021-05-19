using System.IO;

namespace Template
{
    class Score
    {
        public Score()
        {
        }

        public string[] LoadFromFile(string scoreFile)
        {
            string[] lines = File.ReadAllLines(@scoreFile);

            return lines;
        }
    }
}
