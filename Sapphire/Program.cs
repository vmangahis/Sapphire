using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using Sapphire.Contracts;
using Sapphire.Extensions;


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIIS();
builder.Services.AddControllers().AddApplicationPart(typeof(Sapphire.Presentation.AssemblyReference).Assembly);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureNpqSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddControllers(config => { 
//    config.RespectBrowserAcceptHeader = true;
//   config.ReturnHttpNotAcceptable = true;
//}).AddXmlDataContractSerializerFormatters();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Logger
builder.Services.ConfigureLogger();
builder.Logging.ClearProviders();
builder.Host.UseNLog();



var app = builder.Build();
var log = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureException(log);
// Configure the HTTP request pipeline.
if (app.Environment.IsProduction()) {
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});


app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
