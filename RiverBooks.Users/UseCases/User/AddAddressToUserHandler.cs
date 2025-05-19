using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace RiverBooks.Users.UseCases.User
{
    internal class AddAddressToUserHandler : IRequestHandler<AddAddressToUserCommand, Result>
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly ILogger<AddAddressToUserHandler> _logger;

        public AddAddressToUserHandler(ILogger<AddAddressToUserHandler> logger, IApplicationUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(AddAddressToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithAddressByEmailAsync(request.EmailAddress);

            if(user is null)
                return Result.Unauthorized();

            var addressToAdd = new Address(
                request.Street1,
                request.Street2,
                request.City,
                request.State,
                request.PostalCode,
                request.Country);

            var userAddress = user.AddAddress(addressToAdd);
            await _userRepository.SaveChanges();

            _logger.LogInformation("[UseCase] Added address {address} to user {email} (Total: {total} )", userAddress.StreetAddress, request.EmailAddress, user.Address.Count);

            return Result.Success();
        }
    }
}
