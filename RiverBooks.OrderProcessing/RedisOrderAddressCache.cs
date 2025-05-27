using Ardalis.Result;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Text.Json;

namespace RiverBooks.OrderProcessing
{
    internal class RedisOrderAddressCache : IOrderAddressCache
    {
        private readonly IDatabase _db;
        private readonly ILogger<RedisOrderAddressCache> _logger;

        public RedisOrderAddressCache(ILogger<RedisOrderAddressCache> logger)
        {
            var redis = ConnectionMultiplexer.Connect("localhost"); // TODO: Get from configuration
            _db = redis.GetDatabase();
            _logger = logger;
        }

        public async Task<Result<OrderAddress>> GetByIdAsync(Guid id)
        {
            string? fetchedJson = await _db.StringGetAsync(id.ToString());

            if (fetchedJson is null)
            {
                _logger.LogWarning("Address with ID {Id} not found in {db}.", id, "REDIS");
                return Result.NotFound();
            }

            var address = JsonSerializer.Deserialize<OrderAddress>(fetchedJson);

            if(address is null)
                return Result.NotFound();

            _logger.LogInformation("Address with ID {Id} found in {db}.", id, "REDIS");
            return Result.Success(address);
        }
    }
}