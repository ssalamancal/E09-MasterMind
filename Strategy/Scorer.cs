using GamePlay;

namespace Strategy
{
    internal class Scorer
    {
        private bool[] codePositionUsed;
        private bool[] guessPositionUsed;
        private string code;
        private string guess;

        public Scorer(string code, string guess)
        {
            this.code = code;
            this.guess = guess;
            codePositionUsed = new bool[GameEngine.POSITIONS];
            guessPositionUsed = new bool[GameEngine.POSITIONS];
        }

        public static Score scoreGuess(string code, string guess)
        {
            return new Scorer(code, guess).scoreIt();
        }

        private Score scoreIt()
        {
            return new Score(countLettersInPosition(), countLettersOutOfPosition());
        }
        private int countLettersInPosition()
        {
            int inPosition = 0;
            for (int i = 0; i < code.Length; i++)
                if (isInPosition(i))
                    inPosition++;
            return inPosition;
        }

        private bool isInPosition(int i)
        {
            if (code[i] == guess[i])
                return codePositionUsed[i] = guessPositionUsed[i] = true;

            return false;
        }

        private int countLettersOutOfPosition()
        {
            int outOfPosition = 0;
            for (int ic = 0; ic < code.Length; ic++)
                if (isOutOfPosition(ic))
                    outOfPosition++;
            return outOfPosition;
        }

        private bool isOutOfPosition(int ic)
        {
            for (int ig = 0; ig < guess.Length; ig++)
                if (!codePositionUsed[ic] && !guessPositionUsed[ig] && ig != ic && guess[ig] == code[ic])
                    return codePositionUsed[ic] = guessPositionUsed[ig] = true;

            return false;
        }
    }
}