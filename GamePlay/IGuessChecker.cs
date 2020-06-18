namespace GamePlay
{
    public interface IGuessChecker
    {
        bool shouldTry(string guess);
        void addScore(string guess, Score score);
    }
}