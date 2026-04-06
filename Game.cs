namespace GameStore
{
    public class Game
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Units { get; set; }

        public Game(string name, int price, int units)
        {
            Name = name;
            Price = price;
            Units = units;
        }

        public void DecrementUnits()
        {
            if (Units > 0)
                Units--;
        }
    }
}