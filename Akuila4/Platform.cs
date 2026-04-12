namespace GameStore;

// Represents a general game platform store and contains the shared
// purchasing behavior used by derived platform classes.
public abstract class Platform : IPlatform
{

    // Gets the list of games sold by this platform.    
    protected List<Game> Games { get; } = new List<Game>();

    // Gets or sets the selected game.
    protected int SelectedGame { get; set; }

    // Gets or sets the total amount paid by the customer.
    protected decimal AmountPaid {get; set;}

    // Gets the name of the store.
    public abstract string StoreName {get;}
    
    // Runs the full game purchase process in order.
    public void PurchaseGame()
    {
        Introduction();
        SelectGame();
        AcceptPayment();
        DispenseChange();
        DeliverGame();
    }

    // Displays the platform-specific welcome message.
    protected abstract void Introduction();

    // Displays the list of games and allows the user to select
    // one game that is currently in stock.
    protected void SelectGame()
    {
        while(true)
        {
                Console.WriteLine();
                Console.WriteLine($"--- {StoreName} Games ---");
                
                for (int i=0; i < Games.Count; i++)
            {
                    Console.WriteLine($"{i + 1}. {Games[i].Name} - ${Games[i].Price} - Stock: {Games[i].Units}");

            }
            Console.Write("Select a game: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice) &&
                choice >= 1 &&
                choice <= Games.Count &&
                Games[choice - 1].Units > 0)
            {
                SelectedGame = choice - 1;
                break;
            }

            Console.WriteLine("Invalid selection. Choose a game that is in stock");
        }
    }

    // Reads the quantity of a bill denomination and returns
    // the total dollar amount for that denomination.    
    protected decimal ReadBills(string prompt, int denomination)
    {
        int quantity;
        
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out quantity) && quantity >= 0)
            {
                return quantity * denomination;
            }

            Console.WriteLine("Enter a whole number 0 or greater.");
        }
    }

    // Accepts payment using $20 and $10 bills.
    // This is the default payment behavior for the base platform.
    protected virtual void AcceptPayment()
    {
        Console.WriteLine();
        Console.WriteLine("Enter payment quantities");

        AmountPaid = 0;
        AmountPaid += ReadBills("Number of $20 bills: ", 20);
        AmountPaid += ReadBills("Number of $10 bills: ", 10);
    }

    // Dispenses change using $10 and $1 bills.
    // This is the default change behavior for the base platform.
    protected virtual void DispenseChange()
    {
        int change = (int)(AmountPaid - Games[SelectedGame].Price);
        if (change < 0)
        {
            Console.WriteLine("Insufficient payment. No change returned.");
            return;
        }
        int tens = change / 10;
        change %= 10;
        int ones = change;

        Console.WriteLine();
        Console.WriteLine("Change returned:");
        Console.WriteLine($"$10 bills: {tens} ");
        Console.WriteLine($"$1 bills: {ones}");
    }

    // Delivers the selected game only if enough payment was made.
    // Inventory is reduced after a successful purchase.
    protected virtual void DeliverGame()
    {
        if (AmountPaid >= Games[SelectedGame].Price)
        {
            Games[SelectedGame].Decrement();
            Console.WriteLine();
            Console.WriteLine($"Thank you for using the {StoreName}.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Not enough payment. Game cannot be delivered.");
        }
    }
}
