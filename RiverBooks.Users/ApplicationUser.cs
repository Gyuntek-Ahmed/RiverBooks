using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiverBooks.Users
{
    public class ApplicationUser : IdentityUser, IHaveDomainEvents
    {
        public string FullName { get; set; } = string.Empty;

        private readonly List<CartItems> _cartItems = new();

        public IReadOnlyCollection<CartItems> CartItems => _cartItems.AsReadOnly();

        private readonly List<UserStreetAddress> _address = new();

        public IReadOnlyCollection<UserStreetAddress> Address => _address.AsReadOnly();

        private List<DomainEventsBase> _domainEvents = new();
        [NotMapped]
        public IEnumerable<DomainEventsBase> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(DomainEventsBase domainEvent) => _domainEvents.Add(domainEvent);

        void IHaveDomainEvents.ClearDomainEvents() => _domainEvents.Clear();

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

        public UserStreetAddress AddAddress(Address address)
        {
            Guard.Against.Null(address);

            var existingAddress = _address.SingleOrDefault(a => a.StreetAddress == address);

            if (existingAddress != null)
                return existingAddress;

            var newAddress = new UserStreetAddress(Id, address);
            _address.Add(newAddress);

            var domainEvent = new AddressAddedEvent(newAddress);
            RegisterDomainEvent(domainEvent);

            return newAddress;
        }
    }
}