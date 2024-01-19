using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using YahooFinance.Core.Entities;

namespace YahooFinance.Core.Repositories
{
    public class YahooRepository : IYahooRepository
    {
        private readonly IDistributedCache _redisCache;
        public YahooRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }
        public async Task<YahooFinanceClass> GetYahoo(string yahooName)
        {
            var yahooFinance = await _redisCache.GetStringAsync(yahooName);
            if (String.IsNullOrEmpty(yahooFinance))
                return null;

            return JsonConvert.DeserializeObject<YahooFinanceClass>(yahooFinance);
        }
        public async Task<YahooFinanceClass> UpdateYahoo(string yahooName, YahooFinanceClass yahooFinance)
        {
            await _redisCache.SetStringAsync(yahooName, JsonConvert.SerializeObject(yahooFinance));

            return await GetYahoo(yahooName);
        }
        public async Task DeleteYahoo(string yahooName)
        {
            await _redisCache.RemoveAsync(yahooName);
        }
    }
}
