namespace GameStore
{
    /// Represents a game with name, price, and available units.
    public class Game
    {
        // Game title
        public string Name { get; set; }

        // Price of the game (MUST be decimal)
        public decimal Price { get; set; }

        // Available units in stock
        public int Units { get; set; }

        /// Parameterized constructor to initialize a game object.
        public Game(string name, decimal price, int units)
        {
            Name = name;
            Price = price;
            Units = units;
        }

        /// Decreases stock by 1 when a game is purchased.
        public void Decrement()
        {
            if (Units > 0)
                Units--;
        }
    }
}
