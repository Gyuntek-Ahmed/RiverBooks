namespace RiverBooks.OrderProcessing
{
    public class Factory
    {
        public static Order Create(Guid userId, Address shippingAddress, Address billingAddress, IEnumerable<OrderItem> orderItems)
        {
            var order = new Order();

            order.UserId = userId;
            order.ShippingAddress = shippingAddress;
            order.BillingAddress = billingAddress;
            
            foreach (var item in orderItems)
            {
                order.AddOrderItem(item);
            }
            return order;
        }
    }
}
