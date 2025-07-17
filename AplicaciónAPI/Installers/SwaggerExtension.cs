namespace AplicaciónAPI.Installers
{
    public class SwaggerExtension : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Api Kener";
                    document.Info.Description = "ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Mi Perfil LinkedIn",
                        Email = "kenneragv@gmail.com",
                        Url = "https://www.linkedin.com/in/kenner-guti%C3%A9rrez-v%C3%A1squez-3b0479174/"
                    };
                };
            });
        }
    }
}
