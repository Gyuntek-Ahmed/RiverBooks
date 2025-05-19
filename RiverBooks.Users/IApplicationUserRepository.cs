namespace RiverBooks.Users
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetUserWithAddressByEmailAsync(string email);

        Task<ApplicationUser> GetUserWithCartByEmailAsync(string email);

        Task SaveChanges();
    }
}
