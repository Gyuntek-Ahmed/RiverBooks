using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        private readonly List<CartItems> _cartItems = new();

        public IReadOnlyCollection<CartItems> CartItems => _cartItems.AsReadOnly();

        public void AddCartItem(CartItems cartItem)
        {
            Guard.Against.Null(cartItem);

            var existingItem = _cartItems.SingleOrDefault(i => i.BookId == cartItem.BookId);

            if (existingItem != null)
            {
                existingItem.UpdateQuantity(existingItem.Quantity + cartItem.Quantity);
                // TODO: Update the unit price if needed
                return;
            }
            _cartItems.Add(cartItem);
        }
    }

    public class CartItems
    {
        public CartItems(Guid bookId, string description, int quantity, decimal unitPrice)
        {
            BookId = Guard.Against.Default(bookId);
            Description = Guard.Against.NullOrEmpty(description);
            Quantity = Guard.Against.Negative(quantity);
            UnitPrice = Guard.Against.Negative(unitPrice);
        }

        public Guid Id { get; private set; }

        public Guid BookId { get; private set; }

        public string Description { get; set; } = string.Empty;

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        internal void UpdateQuantity(int quantity)
        {
            Quantity = Guard.Against.Negative(quantity);
        }
    }
}
