namespace GameStore;

// Represents the PS5 game store.
// Inherits shared store behavior from Platform.
public class PS5 : Platform
{
    // Gets the name of the PS5 store.
    public override string StoreName => "PS5 Store";

    // Creates a PS5 store and loads its game inventory.
    public PS5()
    {
        Games.Add(new Game("Call of Duty", 54, 3));
        Games.Add(new Game("Elden Ring", 50, 4));
        Games.Add(new Game("Horizon", 46, 5));
        Games.Add(new Game("Uncharted", 57, 2));
    }
    
    // Displays a welcome message for the PS5 store.
    protected override void Introduction()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the PS5 Store.");
    }

    // Accepts payment using $10, $5, and $1 bills for PS5 purchases.
    protected override void AcceptPayment()
    {
        Console.WriteLine();
        Console.WriteLine("Enter payment quantities:");

        AmountPaid = 0;
        AmountPaid += ReadBills("Number of $10 bills: ", 10);
        AmountPaid += ReadBills("Number of $5 bills: ", 5);
        AmountPaid += ReadBills("Number of $1 bills: ", 1);
    }

    // Delivers the selected PS5 game after successful payment.
    protected override void DeliverGame()
    {
        if(AmountPaid >= Games[SelectedGame].Price)
        {
            Games[SelectedGame].Decrement();
            Console.WriteLine();
            Console.WriteLine($"Your PS5 game {Games[SelectedGame].Name} is being delivered");
            Console.WriteLine("Thank you for shopping at the PS5 Store.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Not enough payment. Game cannot be delivered");
        }
    }
}
