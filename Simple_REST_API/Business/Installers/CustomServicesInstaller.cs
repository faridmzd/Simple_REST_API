using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Simple_REST_API.Business.Services;

namespace Simple_REST_API.Business.Installers
{
    public static class CustomServicesInstaller
    {
        
        
        public static void InstallCustomServices(this IServiceCollection services,ConfigurationManager configuration)
        {
            InstallMvcServices(services);
            
            services.AddScoped<INoteService, NoteService>();
            
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        }

        private static void InstallMvcServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddControllers();
        }
    }
}
