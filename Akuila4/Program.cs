using GameStore;

// Main driver for the game store program.
// Displays the platform menu and lets the user continue
// buying games until they choose to exit.
PS5 ps5Store = new PS5();
Switch2 switch2store = new Switch2();

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=== Game Platform Menu ===");
    Console.WriteLine("1. PS5");
    Console.WriteLine("2. Switch2");
    Console.WriteLine("0. Exit");
    Console.Write("Select a platform: ");

    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            ps5Store.PurchaseGame();
            break;

        case "2":
            switch2store.PurchaseGame();
            break;
        
        case "0":
            running = false;
            Console.WriteLine("System shutting down.");
            break;

        default:
            Console.WriteLine("Invalid selection.");
            break;
    }
}
