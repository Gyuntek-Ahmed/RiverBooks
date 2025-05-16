using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCases
{
    public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, Result>
    {
        private readonly IApplicationUserRepository _userRepository;

        public AddItemToCartCommandHandler(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithCartByEmailAsync(request.EmailAddress);
            if (user is null)
                return Result.Unauthorized();

            // TODO: Get description and price from the Book Module
            var cartItem = new CartItems(request.BookId, "description", request.Quantity, 1.00m);

            await _userRepository.SaveChanges();

            return Result.Success();
        }
    }
}
