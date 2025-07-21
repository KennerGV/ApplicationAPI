using ApplicationAPI.Application.Contracts.Services;
using ApplicationAPI.Business.Contracts.Business;
using ApplicationAPI.Application.Services;
using ApplicationAPI.Business.Business;

namespace AplicaciónAPI.Installers
{
    public class WeatherInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBusinessAPI, BusinessAPI>();
            services.AddTransient<IServiceAPI, ServiceAPI>();
        }
    }

}
