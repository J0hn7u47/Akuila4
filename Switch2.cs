using System;

namespace GameStore
{
    /// Represents the Switch2 gaming platform.
    public class Switch2 : Platform
    {
        public override string StoreName { get; set; } = "Switch2";

        public Switch2()
        {
            games.Add(new Game("Animal Crossing", 46m, 3));
            games.Add(new Game("Link’s Awakening", 50m, 5));
            games.Add(new Game("Pokemon Legends", 57m, 1));
        }

        /// Store introduction
        public override void Introduction()
        {
            Console.WriteLine("Welcome to Switch2 Store");
        }

        /// Custom change logic ($5, $2, $1)
        public override void DispenseChange()
        {
            decimal change = totalPaid - selectedGame.Price;

            int fives = (int)(change / 5);
            change %= 5;

            int twos = (int)(change / 2);
            change %= 2;

            int ones = (int)change;

            Console.WriteLine($"$5: {fives}");
            Console.WriteLine($"$2: {twos}");
            Console.WriteLine($"$1: {ones}");
        }
    }
}