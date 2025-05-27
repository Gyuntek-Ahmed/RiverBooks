using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderProcessing.Contracts;

namespace RiverBooks.OrderProcessing.Integrations
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<OrderDetailsResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        private readonly IOrderAddressCache _addressCache;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ILogger<CreateOrderCommandHandler> logger, IOrderAddressCache addressCache)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _addressCache = addressCache;
        }

        public async Task<Result<OrderDetailsResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = request.OrderItems.Select(item => new OrderItem(item.BookId, item.Quantity, item.UnitPrice, item.Description));

            //var shippingAddress = new Address("123 Main", "", "Kent", "OH", "2222", "BG");
            //var billingAddress = shippingAddress;
            var shippingAddress = await _addressCache.GetByIdAsync(request.ShippingAddressId);
            var billingAddress = await _addressCache.GetByIdAsync(request.BillingAddressId);

            var newOrder = 
                Factory
                .Create(request.UserId
                , shippingAddress.Value.Address
                , billingAddress.Value.Address
                , items);

            await _orderRepository.AddAsync(newOrder);
            await _orderRepository.SaveChangesAsync();

            _logger.LogInformation("New Order Created! {OrderId}", newOrder.Id);

            return new OrderDetailsResponse(newOrder.Id);
        }
    }
}
