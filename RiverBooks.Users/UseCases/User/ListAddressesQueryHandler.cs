using Ardalis.Result;
using MediatR;
using RiverBooks.Users.UserEndpoints;

namespace RiverBooks.Users.UseCases.User
{
    internal class ListAddressesQueryHandler : IRequestHandler<ListAddressesQuery, Result<List<UserAddressDto>>>
    {
        private readonly IApplicationUserRepository _userRepository;

        public ListAddressesQueryHandler(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<UserAddressDto>>> Handle(ListAddressesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithAddressByEmailAsync(request.EmailAddress);

            if (user is null)
                return Result<List<UserAddressDto>>.Unauthorized();

            return user!.Address!
                .Select(address => new UserAddressDto(
                    address.Id,
                    address.StreetAddress.Street1,
                    address.StreetAddress.Street2,
                    address.StreetAddress.City,
                    address.StreetAddress.State,
                    address.StreetAddress.PostalCode,
                    address.StreetAddress.Country))
                .ToList();
        }
    }
}
