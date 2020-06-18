using System;

namespace GamePlay
{
    public class GameEngine
    {
        public static readonly string LETTERS = "ABCDEF";
        public static readonly int MAX_LETTERS = LETTERS.Length;
        public static readonly int MAX_CODES = MAX_LETTERS * MAX_LETTERS * MAX_LETTERS * MAX_LETTERS;
        public static readonly int POSITIONS = 4;

        public static IGuessChecker guessChecker;
        public static IConsole console;

        private Guesser guesser;
        private bool gameOver;
        private int tries;

        public GameEngine()
        {
            this.guesser = new Guesser(guessChecker);
        }

        public void play()
        {
            for (tries = 1; !gameOver; tries++)
            {
                tryNextGuess(guesser.getNextGuess());
            }
        }

        private void tryNextGuess(string guess)
        {
            if (guess == null)
                codeNotFound();
            else
                scoreOneGuess(guess);
        }

        private void codeNotFound()
        {
            console.announceGameOver();
            console.announceTries(tries - 1);
            console.announceBadScoring();
            console.waitForExit();
            gameOver = true;
        }

        private void scoreOneGuess(string guess)
        {
            Score score = console.scoreGuess(guess);
            if (isPerfectMatch(score))
                win(guess);
            else
                guesser.rememberScore(guess, score);
        }

        private bool isPerfectMatch(Score score)
        {
            return score.inPosition == 4;
        }

        private void win(string guess)
        {
            console.announceGameOver();
            console.announceWinningCode(guess);
            console.announceTries(tries);
            console.waitForExit();
            gameOver = true;
        }

        
    }
}
