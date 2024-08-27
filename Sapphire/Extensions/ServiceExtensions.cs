using Sapphire.Contracts;
using Sapphire.Repository;
using Sapphire.Service.Contracts;
using Sapphire.Service;
using Sapphire.LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Sapphire.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection serv) =>
            serv.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", b =>
                b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIIS(this IServiceCollection serv) => serv.Configure<IISOptions>(opt => { 
        
        });

        public static void ConfigureLogger(this IServiceCollection serv) => serv.AddSingleton<ILoggerManager, LoggerService.LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection serv) => serv.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection serv) => serv.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureNpqSqlContext(this IServiceCollection serv, IConfiguration conf) => serv.AddDbContext<RepositoryContext>(opt => opt.UseNpgsql(conf.GetConnectionString("DevConnString")));

        public static NewtonsoftJsonPatchInputFormatter ConfigureJSONInputPatchFormatter(this IServiceCollection serv) => serv.AddLogging().AddMvc().AddNewtonsoftJson().Services.BuildServiceProvider().GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
          .OfType<NewtonsoftJsonPatchInputFormatter>().First();
    }
}
