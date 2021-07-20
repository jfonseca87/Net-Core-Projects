using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPICookiesTest.Models;

namespace JWTTestAPIWithCSFRToken.Controllers
{
    [ApiController]
    [Route("api/csfr")]
    [Authorize]
    public class AntiForgeryController : ControllerBase
    {
        private readonly IAntiforgery antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            this.antiforgery = antiforgery;
        }

        [HttpGet]
        public async Task<IActionResult> GenerateAntiForgeryToken()
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
