
using ApplicationAPI.Application.Contracts.Services;
using ApplicationAPI.Application.Services;
using ApplicationAPI.Business.Business;
using ApplicationAPI.Business.Contracts.Business;

namespace AplicaciónAPI.Installers
{
    public class HealthInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IHealthCheckBusiness, HealthCheckBusiness>();
            service.AddTransient<IHealthCheckServices, HealthCheckServices>();
        }
    }
}
