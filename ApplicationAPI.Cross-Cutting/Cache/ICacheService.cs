namespace ApplicationAPI.Cross_Cutting.Cache
{
    public interface ICacheService
    {
        Task<bool> TryGet<T>(string cacheKey, out T value);
        Task<bool> ObtenerValorRedis(string cacheKey, out string value);
        Task<bool> Set<T>(string cacheKey, T value);
        void Remove(string cacheKey);
    }
}
