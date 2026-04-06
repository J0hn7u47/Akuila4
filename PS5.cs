using System;

namespace GameStore
{
    public class PS5 : Platform
    {
        public override string StoreName { get; set; } = "PS5";

        public PS5()
        {
            games.Add(new Game("Call of Duty", 54, 3));
            games.Add(new Game("Elden Ring", 50, 4));
            games.Add(new Game("Horizon", 46, 5));
            games.Add(new Game("Uncharted", 57, 2));
        }

        public override void Introduction()
        {
            Console.WriteLine("Welcome to PS5 Store");
        }

        public override void AcceptPayment()
        {
            Console.WriteLine("$10 bills:");
            totalPaid += int.Parse(Console.ReadLine()!) * 10;

            Console.WriteLine("$5 bills:");
            totalPaid += int.Parse(Console.ReadLine()!) * 5;

            Console.WriteLine("$1 bills:");
            totalPaid += int.Parse(Console.ReadLine()!) * 1;
        }
    }
}