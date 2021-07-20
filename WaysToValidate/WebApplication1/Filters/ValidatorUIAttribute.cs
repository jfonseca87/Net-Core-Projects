using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class ValidatorUIAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (!context.ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                var fieldsWithErrors = context.ModelState.Values.Where(x => x.Errors.Any());

                foreach (var field in fieldsWithErrors)
                {
                    foreach (var error in field.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }


                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}
