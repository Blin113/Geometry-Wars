using System.IO;

namespace Template
{
    class Score
    {
        public Score()
        {
        }

        public void LoadFromFile(string scoreFile)
        {
            string[] lines = File.ReadAllLines(@scoreFile);

            //hscore = lines[0];
        }
    }
}
