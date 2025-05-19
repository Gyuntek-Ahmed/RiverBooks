using Ardalis.GuardClauses;

namespace RiverBooks.Users
{
    public class CartItems
    {
        public CartItems(Guid bookId, string description, int quantity, decimal unitPrice)
        {
            BookId = Guard.Against.Default(bookId);
            Description = Guard.Against.NullOrEmpty(description);
            Quantity = Guard.Against.Negative(quantity);
            UnitPrice = Guard.Against.Negative(unitPrice);
        }

        public CartItems()
        {
            // For EF Core
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid BookId { get; private set; }

        public string Description { get; set; } = string.Empty;

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        internal void UpdateQuantity(int quantity)
        {
            Quantity = Guard.Against.Negative(quantity);
        }

        internal void UpdateDescription(string description)
        {
            Description = Guard.Against.NullOrEmpty(description);
        }

        internal void UpdateUnitPrice(decimal unitPrice)
        {
            UnitPrice = Guard.Against.Negative(unitPrice);
        }
    }
}
