using StackExchange.Redis;

namespace RedisPractice.Data
{
    public interface IRedisDb
    {
        IDatabase GetDatabase();
    }

    public class RedisDb : IRedisDb
    {
        private ConnectionMultiplexer? _redis;

        private readonly IConfiguration _configuration;
        public RedisDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDatabase GetDatabase()
        {
            _redis ??= ConnectionMultiplexer.Connect(_configuration["ConnectionStrings:RedisConnection"]);
            
            return _redis.GetDatabase();
        }
    }

}
