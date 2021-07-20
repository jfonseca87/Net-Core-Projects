using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestCore
{
    public static  class ActionExecutioner
    {
        public static IActionGeneralMessage ActionExecution<T>(Func<T> action)
        {
            try
            {
                return new ActionSuccessMessage
                {
                    Status = (int)HttpStatusCode.OK,
                    Date = DateTime.Now,
                    Data = action.Invoke()
                };
            }
            catch (Exception ex)
            {
                return new ActionErrorMessage
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Date = DateTime.Now,
                    ErrorMessage = "An error has acurred, please contact system administrator",
                    TokenError = Guid.NewGuid()
                };
            }
        }
    }
}
