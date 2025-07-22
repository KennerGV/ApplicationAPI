
using ApplicationAPI.Cross_Cutting.CustomHealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace AplicaciónAPI.Installers
{
    public class HealthCheckInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddHealthChecks().AddCheck<RedisCustomHealthCheck>("Redis HealthCheck");
        }
    }
}
