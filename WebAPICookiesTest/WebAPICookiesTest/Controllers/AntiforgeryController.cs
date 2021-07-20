using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPICookiesTest.Models;

namespace WebAPICookiesTest.Controllers
{
    [ApiController]
    [Route("api/csfr")]
    public class AntiforgeryController : Controller
    {
        private readonly IAntiforgery antiforgery;

        public AntiforgeryController(IAntiforgery antiforgery)
        {
            this.antiforgery = antiforgery;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GenerateAntiforegeryToken()
        {
            await Task.Run(() =>
            {
                var token = antiforgery.GetAndStoreTokens(HttpContext);
                HttpContext.Response.Cookies.Append("XSRF-REQUEST-TOKEN", token.RequestToken, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    HttpOnly = false
                });
            });

            return new OkObjectResult(new APIResponse<bool>
            {
                Status = (int)HttpStatusCode.OK,
                Message = string.Empty,
                Data = true
            });
        }
    }
}
