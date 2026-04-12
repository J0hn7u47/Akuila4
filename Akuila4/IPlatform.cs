namespace GameStore
{
     /// Interface that defines the basic behavior of a game platform.
    /// Acts as a contract that all platforms must follow.
    public interface IPlatform
    {
        // Name of the store (PS5 or Switch2)
        string StoreName { get }
        // Controls the full purchasing process
        void PurchaseGame();
    }
}
