using Sapphire.Contracts;
using Sapphire.Repository;

namespace Sapphire.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection serv) => serv.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", builder => {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

        });

        public static void ConfigureIIS(this IServiceCollection serv) => serv.Configure<IISOptions>(opt => { 
        
        });

        public static void ConfigureRepositoryManager(this IServiceCollection serv) => serv.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
