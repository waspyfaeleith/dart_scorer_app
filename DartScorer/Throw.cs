using System;
namespace DartScorer
{
    public class Throw
    {
        private int score;

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        //public Throw() {
            
        //}

        public Throw(int score)
        {
            this.score = score;
        }

        public bool IsValid()
        {
            int[] validHighScores = { 180, 177, 174, 171, 170, 168, 167, 165, 164 };
            int pos = Array.IndexOf(validHighScores, this.score);

            if ((pos > -1) || (this.score >= 0 && this.score < 163))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
