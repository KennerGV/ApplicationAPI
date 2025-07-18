using ApplicationAPI.Cross_Cutting.Cache;
using ApplicationAPI.Cross_Cutting.Config;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace AplicaciónAPI.Installers
{
    public class CacheServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddMemoryCache();
            service.AddTransient<MemoryCacheService>();
            service.AddTransient<RedisCacheService>();

            RedisCacheConfig(service, configuration);

            service.AddTransient<Func<CacheTech, ICacheService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case CacheTech.Memory:
                        return serviceProvider.GetService<MemoryCacheService>();
                    case CacheTech.Redis:
                        return serviceProvider.GetService<RedisCacheService>();
                    default:
                        return serviceProvider.GetService<MemoryCacheService>();
                }
            });
        }
        private static void RedisCacheConfig(IServiceCollection services, IConfiguration configuration)
        {

            var cacheConfig = new CacheConfiguration();

            configuration.GetSection("Cache_Config").Bind(cacheConfig);

            services.AddSingleton(cacheConfig);

            if (cacheConfig.CacheTech != 0)
            {
                return;
            }

            string con_str = $"{cacheConfig.Endpoint}:{cacheConfig.Port}, password ={cacheConfig.Key}";

            services.AddSingleton<IConnectionMultiplexer>(_ =>
            {
                var configurationOptions = ConfigurationOptions.Parse(con_str);
                configurationOptions.AbortOnConnectFail = false; // opcional para evitar crash si Redis no está
                return ConnectionMultiplexer.Connect(configurationOptions);
            });

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = con_str;
                options.InstanceName = cacheConfig.InstanceName;
            });

        }
    }
}
