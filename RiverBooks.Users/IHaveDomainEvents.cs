namespace RiverBooks.Users
{
    public interface IHaveDomainEvents
    {
        IEnumerable<DomainEventsBase> DomainEvents { get; }
        void ClearDomainEvents();
    }
}