using System;
using GameStore;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. PS5\n2. Switch2\n3. Exit");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 3) break;

            Platform platform = choice == 1 ? new PS5() : new Switch2();
            platform.PurchaseGame();
        }
    }
}