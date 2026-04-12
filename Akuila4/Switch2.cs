namespace GameStore;

// Represents the Switch2 game store.
// Inherits shared store behavior from Platform.
public class Switch2 : Platform
{
    // Gets the name of the Switch2 store.
    public override string StoreName => "Switch2 Store";

    // Creates a Switch2 store and loads its game inventory.
    public Switch2()
    {
        Games.Add(new Game("Animal Crossing", 46, 3));
        Games.Add(new Game("Link's Awakening", 50, 5));
        Games.Add(new Game("Pokemon Legends", 57, 1));
    }

    // Displays a welcome message for the Switch2 store.
    protected override void Introduction()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Switch2 Store.");
    }

    // Dispenses change using $5, $2, and $1 bills for Switch2 purchases.
    protected override void DispenseChange()
    {
        int change = (int)(AmountPaid - Games[SelectedGame].Price);

        if (change < 0)
        {
            Console.WriteLine("Insufficient payment. No change returned.");
            return;
        }

        int fives = change / 5;
        change %= 5;
        
        int twos = change / 2;
        change %= 2;

        int ones = change;

        Console.WriteLine();
        Console.WriteLine("Change returned:");
        Console.WriteLine($"$5 bills: {fives}");
        Console.WriteLine($"$2 bills: {twos}");
        Console.WriteLine($"$1 bills: {ones}");
    }

    // Delivers the selected Switch2 game after successful payment.
    protected override void DeliverGame()
    {
        if (AmountPaid >= Games[SelectedGame].Price)
        {
            Games[SelectedGame].Decrement();
            Console.WriteLine();
            Console.WriteLine($"Your Switch2 game {Games[SelectedGame].Name} is being delivered.");
            Console.WriteLine("Thank you for shopping at the Switch2 Store.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Not enough payment. Game cannot be delivered.");
        }
    }
}
