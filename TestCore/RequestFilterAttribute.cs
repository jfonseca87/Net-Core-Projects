using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestCore
{
    public class RequestFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is OkObjectResult)
            {
                var result = context.Result as OkObjectResult;

                context.Result = new OkObjectResult(new ActionSuccessMessage
                {
                    Status = (int)HttpStatusCode.OK,
                    Date = DateTime.UtcNow,
                    Data = result.Value
                });
            }
            else
            {
                var result = context.Result as BadRequestObjectResult;
                var exception = result.Value as Exception;
                string exceptionName = exception.GetType().Name;
                int status = 0;

                if (exceptionName.Equals("ArgumentNullException", StringComparison.InvariantCultureIgnoreCase))
                {
                    status = (int)HttpStatusCode.NotFound;
                }

                context.Result = new OkObjectResult(new ActionErrorMessage
                {
                    Status = status,
                    Date = DateTime.UtcNow,
                    ErrorMessage = exception.Message
                });
            }
        }
    }
}
