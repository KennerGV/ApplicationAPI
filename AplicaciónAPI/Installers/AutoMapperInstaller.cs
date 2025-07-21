using ApplicationAPI.Application.Mappers;
using AutoMapper;

namespace AplicaciónAPI.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton(provider =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<WeatherMappingProfile>();
                }, loggerFactory);

                return config.CreateMapper();
            });
        }
    }
}
