using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using TestEFCore.Services.SqlImplementations;

namespace TestEFCore.CustomFilters
{
    public class DocumentTypeAttribute : ActionFilterAttribute
    {
        public async override void OnActionExecuting(ActionExecutingContext context)
        {
            var result = await new Validations().IsCCDocumentType();

            if (result)
            {
                Trace.WriteLine("There is a CC document type available");
            } 
            else
            {
                Trace.WriteLine("There is not a CC document type available");
            }
        }
    }
}
