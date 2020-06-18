using System;
using System.Collections.Generic;
using GamePlay;

namespace Strategy
{
    public class RememberingGuessChecker : IGuessChecker
    {
        private List<ScoreRecord> scoreHistory = new List<ScoreRecord>();
        public bool shouldTry(string guess)
        {
            return isGuessConsistentWithHistory(guess);
        }

        private bool isGuessConsistentWithHistory(string guess)
        {
            string assumedCode = guess;

            foreach (ScoreRecord previous in scoreHistory)
                if (Scorer.scoreGuess(assumedCode, previous.guess).Equals(previous.score) == false)
                    return false;

            return true;
        }

        public void addScore(string guess, Score score)
        {
            scoreHistory.Add(new ScoreRecord(guess, score));
        }
    }

    internal class ScoreRecord
    {
        public string guess;
        public Score score;

        public ScoreRecord(string guess, Score score)
        {
            this.guess = guess;
            this.score = score;
        }
    }
}
