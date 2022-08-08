namespace Simple_REST_API.Business.Installers
{
    public static class CustomServicesInstaller
    {

        public static void InstallCustomServices(this IServiceCollection services)
        {
            InstallMvcServices(services);
        }

        private static void InstallMvcServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddControllers();
        }
    }
}
