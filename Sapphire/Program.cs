using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using Sapphire.Contracts;
using Sapphire.Extensions;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Shared.DTO;
using Sapphire.Service;






var builder = WebApplication.CreateBuilder(args);
var newtonSoft = builder.Services.ConfigureJSONInputPatchFormatter();
builder.Services.ConfigureCors();
builder.Services.AddScoped<IDataShaper<HunterDTO>, DataShaper<HunterDTO>>();
builder.Services.ConfigureIIS();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.ConfigureLogger();
builder.Services.AddControllers().AddApplicationPart(typeof(Sapphire.Presentation.AssemblyReference).Assembly);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureNpqSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.InputFormatters.Insert(0, newtonSoft);
});
builder.Services.Configure<ApiBehaviorOptions>(opt => {
    opt.SuppressModelStateInvalidFilter = true;
});
//builder.Services.ConfigureAPIVersioning();





var app = builder.Build();
app.ConfigureException();

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
