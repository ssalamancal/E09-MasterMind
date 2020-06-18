using System;

namespace GamePlay
{
    internal class Guesser
    {
        private IGuessChecker guessChecker;
        private int guessIndex = 0;

        public Guesser(IGuessChecker guessChecker)
        {
            this.guessChecker = guessChecker;
        }

        public string getNextGuess()
        {
            while (true)
            {
                string guess = makeGuess(guessIndex++);

                if (guess == null)
                    return null;

                if (guessChecker.shouldTry(guess))
                    return guess;
            }
        }

        public static string makeGuess(int guessIndex)
        {
            if (guessIndex < 0 || guessIndex >= GameEngine.MAX_CODES)
                return null;

            return buildGuess(guessIndex);
        }

        private static string buildGuess(int guessIndex)
        {
            int n = GameEngine.MAX_LETTERS;

            int d1 = guessIndex % n;
            int d2 = (guessIndex / n) % n;
            int d3 = (guessIndex / (n * n)) % n;
            int d4 = (guessIndex / (n * n * n) % n);

            return string.Format("{0}{1}{2}{3}", GameEngine.LETTERS[d4], GameEngine.LETTERS[d3], GameEngine.LETTERS[d2], GameEngine.LETTERS[d1]);
        }
        
        public void rememberScore(string guess, Score score)
        {
            guessChecker.addScore(guess, score);
        }
    }
}