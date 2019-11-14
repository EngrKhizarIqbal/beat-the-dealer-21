using System;

namespace BeatDealer21.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player
            {
                Name = "Sam"
            };

            var game = new TwoPlayerBlackJackGame(player);
            var playAgain = "true";
            do
            {
                game.StartGame();

                Console.WriteLine($"{Environment.NewLine}Game End. Do you want to play again? 'Y' to play again or any other key to exit.");
                playAgain = Console.ReadLine();
            }
            while (playAgain.ToLower().Trim() == "y");
        }
    }
}
