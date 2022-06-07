using System;

namespace CheckersOnConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            CheckersConsoleUI checkersGame = new CheckersConsoleUI();

            checkersGame.StartTheGame();

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
