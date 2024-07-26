using Microsoft.AspNetCore.Diagnostics;
using Sapphire.Contracts;
using Sapphire.Entities.ErrorModel;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Exceptions.NotFound;
using System.Net;

namespace Sapphire.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureException(this WebApplication app) {
            app.UseExceptionHandler(error => {

                error.Run(async cont => {
                    cont.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    cont.Response.ContentType = "application/json";

                    var contFeat = cont.Features.Get<IExceptionHandlerFeature>();
                    if (contFeat != null) {
                        cont.Response.StatusCode = contFeat.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        await cont.Response.WriteAsync(new ErrorDetails() { 
                            StatusCode = cont.Response.StatusCode,
                            Message = contFeat.Error.Message,
                        }.ToString());
                    
                    }
                });
            });
        }
    }
}
