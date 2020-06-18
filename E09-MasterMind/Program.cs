using GamePlay;
using Strategy;

namespace GameInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine.guessChecker = new RememberingGuessChecker();
            GameEngine.console = new GameConsole();

            new GameEngine().play();
        }
    }
}
