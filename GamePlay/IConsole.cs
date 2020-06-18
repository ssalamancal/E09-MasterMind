namespace GamePlay
{
    public interface IConsole
    {
        Score scoreGuess(string guess);
        void announceGameOver();
        void announceWinningCode(string guess);
        void announceTries(int tries);
        void announceBadScoring();
        void waitForExit();
    }
}