namespace RiverBooks.Users
{
    internal sealed class AddressAddedEvent : DomainEventsBase
    {
        public AddressAddedEvent(UserStreetAddress newAddress)
        {
            NewAddress = newAddress;
        }
        public UserStreetAddress NewAddress { get; }
    }
}