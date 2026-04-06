using System;

namespace GameStore
{
    public class Switch2 : Platform
    {
        public override string StoreName { get; set; } = "Switch2";

        public Switch2()
        {
            games.Add(new Game("Animal Crossing", 46, 3));
            games.Add(new Game("Link’s Awakening", 50, 5));
            games.Add(new Game("Pokemon Legends", 57, 1));
        }

        public override void Introduction()
        {
            Console.WriteLine("Welcome to Switch2 Store");
        }

        public override void DispenseChange()
        {
            int change = totalPaid - selectedGame.Price;

            int fives = change / 5;
            change %= 5;

            int twos = change / 2;
            change %= 2;

            int ones = change;

            Console.WriteLine($"$5: {fives}");
            Console.WriteLine($"$2: {twos}");
            Console.WriteLine($"$1: {ones}");
        }
    }
}