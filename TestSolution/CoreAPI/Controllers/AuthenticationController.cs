using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return Ok(CoreAPI.Login.GenerateToken(new CoreAPI.User
            {
                UserId = 1,
                UserName = "pperez",
                Email = "pperez@domain.com",
                Role = "User"
            }));
        }
    }
}
