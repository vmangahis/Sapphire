using Microsoft.AspNetCore.Diagnostics;
using Sapphire.Contracts;
using Sapphire.Entities.ErrorModel;
using System.Net;

namespace Sapphire.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureException(this WebApplication app, ILoggerManager manager) {
            app.UseExceptionHandler(error => {

                error.Run(async cont => {
                    cont.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    cont.Response.ContentType = "application/json";

                    var contFeat = cont.Features.Get<IExceptionHandlerFeature>();
                    if (contFeat != null) {
                        manager.LogError($"Something threw an error: {contFeat.Error}");

                        await cont.Response.WriteAsync(new ErrorDetails() { 
                            StatusCode = cont.Response.StatusCode,
                            Message = "server error",
                        }.ToString());
                    
                    }
                });
            });
        }
    }
}
