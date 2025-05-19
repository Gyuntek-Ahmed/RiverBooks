using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        private readonly List<CartItems> _cartItems = new();

        public IReadOnlyCollection<CartItems> CartItems => _cartItems.AsReadOnly();

        public void AddItemToCart(CartItems cartItem)
        {
            Guard.Against.Null(cartItem);

            var existingItem = _cartItems.SingleOrDefault(i => i.BookId == cartItem.BookId);

            if (existingItem != null)
            {
                existingItem.UpdateQuantity(existingItem.Quantity + cartItem.Quantity);
                existingItem.UpdateDescription(cartItem.Description);
                existingItem.UpdateUnitPrice(cartItem.UnitPrice);
                return;
            }
            _cartItems.Add(cartItem);
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}
