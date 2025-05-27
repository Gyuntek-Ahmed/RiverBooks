using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RiverBooks.Users.Data
{
    public class UsersDbContext : IdentityDbContext
    {
        private readonly IDomainEventDispatcher? _dispatcher;

        public UsersDbContext(DbContextOptions<UsersDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
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

        /// <summary>
        /// This is needed for domain events to work
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Ignore events if no dispatcher provided
            if(_dispatcher == null)
                return result;

            // Dispatch domain events only if save was successful
            var entitiesWithEvents = ChangeTracker
                .Entries<IHaveDomainEvents>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);
            return result;
        }
    }
}
