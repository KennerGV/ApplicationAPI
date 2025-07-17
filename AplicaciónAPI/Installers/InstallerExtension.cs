using Microsoft.AspNetCore.Hosting;

namespace AplicaciónAPI.Installers
{
    public static class InstallerExtension
    {
        public static void InstallServiceInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            //var configuration = IConfiguration;
            var installers = typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();
            installers.ForEach(installers => installers.InstallServices(services, configuration));
        }
    }
}
