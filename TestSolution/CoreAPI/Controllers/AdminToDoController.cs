using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [ApiController]
    [Route("api/admintodo")]
    [Authorize(Roles = "Admin")]
    public class AdminToDoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToDo()
        {
            return Ok("Data from admin todo list");
        }

        [HttpPost]
        public IActionResult SaveAdminToDo()
        {
            return Ok("Admin ToDo created successfully");
        }
    }
}
