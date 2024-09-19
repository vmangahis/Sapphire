using Sapphire.Contracts;
using Sapphire.Repository;
using Sapphire.Service.Contracts;
using Sapphire.Service;
using Sapphire.LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Asp.Versioning;
using Marvin.Cache.Headers;
using AspNetCoreRateLimit;
using Sapphire.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Sapphire.Entities.ConfigurationModel;

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
        public static void ConfigureNpqSqlContext(this IServiceCollection serv, IConfiguration conf) => serv.AddDbContext<RepositoryContext>(opt => {
            opt.UseNpgsql(conf.GetConnectionString("DevConnString"));
          
        });

        public static NewtonsoftJsonPatchInputFormatter ConfigureJSONInputPatchFormatter(this IServiceCollection serv) => serv.AddLogging().AddMvc().AddNewtonsoftJson().Services.BuildServiceProvider().GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
          .OfType<NewtonsoftJsonPatchInputFormatter>().First();

        public static void ConfigureAPIVersioning(this IServiceCollection serv)
        {
            serv.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1.0);
                
            }).AddMvc();
        }

        public static void ConfigureResponseCache(this IServiceCollection serv) => serv.AddResponseCaching();
        public static void ConfigureHttpCacheHeaders(this IServiceCollection serv) => serv.AddHttpCacheHeaders(
            expopt => {
                expopt.MaxAge = 30;
                expopt.CacheLocation = CacheLocation.Private;
            },
            valopt => {
                valopt.MustRevalidate = true;
            });

        public static void ConfigureRateLimiting(this IServiceCollection serv)
        { 
            var rateLimitRule = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit = 30,
                    Period = "10s"
                }
            };
            serv.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRule;
            });
            serv.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            serv.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            serv.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            serv.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }

        public static void ConfigureIdentity(this IServiceCollection serv)
        {
            var build = serv.AddIdentity<SapphireUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 5;
                opt.User.RequireUniqueEmail = true;
                opt.ClaimsIdentity.UserIdClaimType = "UserId";

            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection serv, IConfiguration conf)
        {
            var jwtOptions = new JwtConfig();
            conf.Bind(jwtOptions.Section, jwtOptions);
            var secretKey = Environment.GetEnvironmentVariable("SUPERSECRET");


            serv.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt => {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtOptions.ValidIssuer,
                    ValidAudience = jwtOptions.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };

                opt.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Request.Cookies.TryGetValue("accessToken", out var accessToken);
                        if (string.IsNullOrWhiteSpace(accessToken))
                            context.Token = accessToken;

                        return Task.CompletedTask;
                    }



                };
            });
        }



    }
}
