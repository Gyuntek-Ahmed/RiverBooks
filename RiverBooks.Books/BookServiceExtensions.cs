using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Books.Data;
using Serilog;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookModuleServices(this IServiceCollection services, ConfigurationManager config, ILogger logger, List<System.Reflection.Assembly> mediatRAssemblies)
    {
        string? connectionString = config.GetConnectionString("BooksConnectionString");

        services
            .AddDbContext<BookDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IBookRepository, EFBookRepository>();
        services.AddScoped<IBookService, BookService>();

        mediatRAssemblies.Add(typeof(BookServiceExtensions).Assembly);

        logger.Information("{Module} module services registered", "Books");

        return services;
    }
}
