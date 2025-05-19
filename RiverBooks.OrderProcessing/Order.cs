namespace RiverBooks.OrderProcessing
{
    public class Order
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Address ShippingAddress { get; set; } = default!;

        public Address BillingAddress { get; set; } = default!;

        private readonly List<OrderItem> _orderItems = new();

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public DateTimeOffset DateCreated { get; private set; } = DateTimeOffset.UtcNow;

        public void AddOrderItem(OrderItem item) => _orderItems.Add(item);
    }
}
