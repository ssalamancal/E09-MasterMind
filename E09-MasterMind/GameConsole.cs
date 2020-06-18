using System;
using System.IO;
using GamePlay;

namespace GameInterface
{
    internal class GameConsole : IConsole
    {
        public Score scoreGuess(string guess)
        {
            Console.WriteLine($"Enter score for {guess}");
            string guessString = readLine();

            return new Score(count(guessString, '+'), count(guessString, '-'));
        }

        private string readLine()
        {
            try
            {
                return Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private int count(string guessString, char c)
        {
            int count = 0;

            for (int i = 0; i < guessString.Length; i++)
            {
                if (guessString[i] == c) count++;
            }

            return count;
        }

        public void announceGameOver()
        {
            Console.WriteLine("Game over.");
        }

        public void announceWinningCode(string guess)
        {
            Console.WriteLine($"Winning code = {guess}");
        }

        public void announceTries(int tries)
        {
            Console.WriteLine($"tries = {tries}");
        }

        public void announceBadScoring()
        {
            Console.WriteLine("Sorry, but you're scoring was less than perfectly accurate.");
        }

        public void waitForExit()
        {
            Console.ReadLine();
        }
    }
}