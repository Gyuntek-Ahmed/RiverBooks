using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RiverBooks.Users
{
    public static class UsersModuleExtensions
    {
        public static IServiceCollection AddUsersModuleServices(this IServiceCollection services, ConfigurationManager config)
        {
            string? connectionString = config.GetConnectionString("UsersConnection");
            services.AddDbContext<UsersDbContext>(config =>
                config.UseSqlServer(connectionString));

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<UsersDbContext>();

            return services;
        }
    }

    public class UsersDbContext : IdentityDbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Users");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<decimal>()
                .HavePrecision(18, 6);
        }
    }
}
