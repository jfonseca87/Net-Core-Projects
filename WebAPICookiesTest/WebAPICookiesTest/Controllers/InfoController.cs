using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebAPICookiesTest.Models;

namespace WebAPICookiesTest.Controllers
{
    [ApiController]
    [Route("api/Info")]
    public class InfoController : Controller
    {
        [HttpGet]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetInfo()
        {
            return await Task.Run(() =>
            {
                return new OkObjectResult(new APIResponse<string>
                {
                    Status = (int)HttpStatusCode.OK,
                    Message = string.Empty,
                    Data = $"Sensible data from { HttpContext.User.Identity.Name }"
                });
            });
        }
    }
}
