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

            new TwoPlayerBlackJackGame(player).StartGame();

            Console.ReadKey();
        }
    }
}
