 using System;
using System.Collections.Generic;

namespace GameStore
{
    /// Abstract class that implements the IPlatform interface.
    public abstract class Platform : IPlatform
    {
        // List of games available on the platform
        protected List<Game> games = new List<Game>();

        // The game selected by the user for purchase
        protected Game selectedGame = null!;

        // Total amount paid by the user during the purchase process
        protected decimal totalPaid = 0m;

        /// Abstract property for store name
        public abstract string StoreName { get; set; }

        /// Abstract method to introduce the store
        public abstract void Introduction();

        /// Implements the full purchase process
        public void PurchaseGame()
        {
            totalPaid = 0m;
            Introduction();
            SelectGame();
            AcceptPayment();
            DispenseChange();
            DeliverGame();
        }

        /// Allows the user to select a game
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

        /// Default payment method ($20 and $10)
        public virtual void AcceptPayment()
        {
            Console.WriteLine("$20 bills:");
            totalPaid += int.Parse(Console.ReadLine()!) * 20m;

            Console.WriteLine("$10 bills:");
            totalPaid += int.Parse(Console.ReadLine()!) * 10m;
        }

        /// Default change dispensing ($10 and $1)
        public virtual void DispenseChange()
        {
            decimal change = totalPaid - selectedGame.Price;

            int tens = (int)(change / 10);
            change %= 10;

            int ones = (int)change;

            Console.WriteLine($"$10: {tens}");
            Console.WriteLine($"$1: {ones}");
        }

        /// Deliver the game
        public void DeliverGame()
        {
            Console.WriteLine($"Delivering {selectedGame.Name}...");
        }
    }
}