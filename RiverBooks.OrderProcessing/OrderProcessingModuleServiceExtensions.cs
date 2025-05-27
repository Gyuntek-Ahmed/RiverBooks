using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace RiverBooks.OrderProcessing
{
    using System.Collections.Generic;
    /// <summary>
    /// Extension methods for adding Order Processing module services.
    /// </summary>
    public static class OrderProcessingModuleServiceExtensions
    {
        public static IServiceCollection AddOrderProcessingModuleServices(this IServiceCollection services, ConfigurationManager config, ILogger logger, List<System.Reflection.Assembly> mediatRAssemblies)
        {
            string? connectionString = config.GetConnectionString("OrderProcessingConnectionString");
            services.AddDbContext<OrderProcessingDbContext>(config =>
                config.UseSqlServer(connectionString));
            // Add services
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<IOrderAddressCache, RedisOrderAddressCache>();

            mediatRAssemblies.Add(typeof(OrderProcessingModuleServiceExtensions).Assembly);

            logger.Information("{Module} module services registered", "OrderProcessing");

            return services;
        }
    }
}
