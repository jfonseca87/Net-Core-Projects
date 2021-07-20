using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPICookiesTest.Models;

namespace WebAPICookiesTest.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        [HttpPost("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User user)
        {
            if (user == null)
            {
                return new BadRequestObjectResult(new APIResponse<bool>
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Message = "The parameter user is null",
                    Data = false
                });
            }

            if (user.UserName != "pperez")
            {
                return new BadRequestObjectResult(new APIResponse<bool>
                {
                    Status = (int)HttpStatusCode.Unauthorized,
                    Message = "The user doesn't exists",
                    Data = false
                });
            }

            if (user.Password != "abc123")
            {
                return new BadRequestObjectResult(new APIResponse<bool>
                {
                    Status = (int)HttpStatusCode.Unauthorized,
                    Message = "The password doesn't match",
                    Data = false
                });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await Request.HttpContext.SignInAsync("Cookies", claimsPrincipal);

            return new OkObjectResult(new APIResponse<bool>
            {
                Status = (int)HttpStatusCode.OK,
                Message = "Process successfully done",
                Data = true
            });
        }

        [HttpGet("LogOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            var user = HttpContext.User.Identity.Name;
            await Request.HttpContext.SignOutAsync();
            return new OkObjectResult(new APIResponse<bool>
            {
                Status = (int)HttpStatusCode.OK,
                Message = "Process successfully done",
                Data = true
            });
        }
    }
}
