using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public ValidationFilterAttribute() { }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var ctrl = context.RouteData.Values["controller"];

            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("dto", StringComparison.InvariantCultureIgnoreCase)).Value;
            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null for controller - {ctrl} and action of {action}");
                return;
            }
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            
        }
    }
}
