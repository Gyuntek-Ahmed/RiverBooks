using MediatR;

namespace RiverBooks.Users
{
    public abstract class DomainEventsBase : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}