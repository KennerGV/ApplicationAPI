using ApplicationAPI.Cross_Cutting.Config;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;

namespace ApplicationAPI.Cross_Cutting.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly CacheConfiguration _cacheConfig;
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisCacheService(IDistributedCache distributedCache,
                                     IOptions<CacheConfiguration> cacheConfig,
                                     IConnectionMultiplexer redis)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
            _cacheConfig = cacheConfig.Value;

            try
            {
                _redis = redis ?? throw new ArgumentNullException(nameof(redis));
                _db = _redis.GetDatabase(_cacheConfig.DefaultDatabase);
            }
            catch (Exception)
            {
                Log.Information("Error en rediscache service");
                throw;
            }
        }
        public Task<bool> ObtenerValorRedis(string cacheKey, out string value)
        {
            value = default;
            var result = true;

            var entity = _db.StringGet(cacheKey);
            if (!entity.IsNull)
            {
                value = entity.ToString();
                result = true;
            }
            else
            {
                result = false;
                value = default;
            }


            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        public async void Remove(string cacheKey)
        {
            try
            {
                await _distributedCache.RemoveAsync(cacheKey);
            }
            catch (Exception)
            {
                Log.Error("Error en Rediscache service remove");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> Set<T>(string cacheKey, T value)
        {
            try
            {
                var cacheList = JsonConvert.SerializeObject(value);
                return await _db.StringSetAsync(cacheKey,
                                                cacheList,
                                                TimeSpan.FromSeconds(5 * 60),
                                                When.NotExists,
                                                CommandFlags.None);
            }
            catch (Exception)
            {
                Log.Error("Error en RedisCache service Set");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<bool> TryGet<T>(string cacheKey, out T value)
        {
            value = default;
            var result = true;

            //Validate DB available
            try
            {
                var entity = _db.StringGet(cacheKey);
                if (!entity.IsNull)
                {
                    value = JsonConvert.DeserializeObject<T>(entity);
                    result = true;
                }
                else
                {
                    result = false;
                    value = default;
                }

            }
            catch (Exception)
            {
                Log.Error("Error en RedisCache service TryGet");
                throw;
            }
            return Task.FromResult(result);
        }
    }
}
