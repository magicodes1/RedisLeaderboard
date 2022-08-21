using Newtonsoft.Json;
using RedisPractice.Data;
using RedisPractice.Models;
using StackExchange.Redis;

namespace RedisPractice.Services
{

    public interface IRankService
    {
        Task<List<RankResponse>> Range(int start, int ent);
        Task<bool> Update(GetScoreRequest request);
    }

    public class RankService : IRankService
    {

        private readonly IRedisDb _redisDb;

        private const string RedisKey = "PLAYER_LEADERBOARD";

        public RankService(IRedisDb redisDb)
        {
            _redisDb = redisDb;
        }


        public async Task<List<RankResponse>> Range(int start, int ent)
        {
            var ranks = await _redisDb.GetDatabase().SortedSetRangeByRankWithScoresAsync(RedisKey, start, ent,Order.Descending);

            var result = new List<RankResponse>();

            foreach (var rank in ranks)
            {
                GetScoreRequest player = JsonConvert.DeserializeObject<GetScoreRequest>(rank.Element!)!;

                result.Add(new RankResponse { Id = player!.Id, PlayerName = player.PlayerName, Score = rank.Score });
            }
            return result;
        }

        public async Task<bool> Update(GetScoreRequest request)
        {
            string data = JsonConvert.SerializeObject(request);
            Random rand = new Random();
            int score = rand.Next(1, 100);
            return await _redisDb.GetDatabase().SortedSetAddAsync(RedisKey, data, 8,SortedSetWhen.Always);
        }
    }
}
