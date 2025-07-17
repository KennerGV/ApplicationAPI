using ApplicationAPI.Cross_Cutting.Config;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ApplicationAPI.Cross_Cutting.Cache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheConfiguration _cacheConfig;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        public MemoryCacheService(IMemoryCache memoryCache, IOptions<CacheConfiguration> cacheConfig)
        {
            _memoryCache = memoryCache;
            _cacheConfig = cacheConfig.Value;
            _cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(_cacheConfig.AbsoluteExpiration),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(_cacheConfig.SlidingExpiration)
            };
        }
        public Task<bool> ObtenerValorRedis(string cacheKey, out string value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        public Task<bool> Set<T>(string cacheKey, T value)
        {
            Task<bool> result = Task.FromResult(false);
            var setter = _memoryCache.Set(cacheKey, value, _cacheOptions);
            if (setter != null)
            {
                result = Task.FromResult(true);
            }
            return result;
        }

        public Task<bool> TryGet<T>(string cacheKey, out T value)
        {
            _memoryCache.TryGetValue<T>(cacheKey, out value);
            return Task.FromResult(value != null);
        }
    }
}
