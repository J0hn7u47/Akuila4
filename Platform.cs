 using System;
using System.Collections.Generic;

namespace GameStore
{
    public abstract class Platform : IPlatform
    {
        protected List<Game> games = new List<Game>();
        protected Game selectedGame = null!;
        protected int totalPaid = 0;

        public abstract string StoreName { get; set; }

        public abstract void Introduction();

        public void PurchaseGame()
        {
            totalPaid = 0;
            Introduction();
            SelectGame();
            AcceptPayment();
            DispenseChange();
            DeliverGame();
        }

        public void SelectGame()
        {
            Console.WriteLine("\nSelect Game:");

            for (int i = 0; i < games.Count; i++)
                Console.WriteLine($"{i + 1}. {games[i].Name} - ${games[i].Price} ({games[i].Units})");

            int choice = int.Parse(Console.ReadLine()!);
            selectedGame = games[choice - 1];

            if (selectedGame.Units > 0)
                selectedGame.DecrementUnits();
            else
            {
                Console.WriteLine("Out of stock!");
                SelectGame();
            }
        }

        public virtual void AcceptPayment()
        {
            Console.WriteLine("$20 bills:");
            totalPaid += int.Parse(Console.ReadLine()!) * 20;

            Console.WriteLine("$10 bills:");
            totalPaid += int.Parse(Console.ReadLine()!) * 10;
        }

        public virtual void DispenseChange()
        {
            int change = totalPaid - selectedGame.Price;

            int tens = change / 10;
            change %= 10;

            int ones = change;

            Console.WriteLine($"$10: {tens}");
            Console.WriteLine($"$1: {ones}");
        }

        public void DeliverGame()
        {
            Console.WriteLine($"Delivering {selectedGame.Name}...");
        }
    }
}