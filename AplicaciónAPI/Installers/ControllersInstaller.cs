
namespace AplicaciónAPI.Installers
{
    public class ControllersInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddControllers();
        }
    }
}
