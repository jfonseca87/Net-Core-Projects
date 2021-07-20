using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToDo()
        {
            return Ok("Data from ToDo");
        }

        [HttpPost]
        public IActionResult SaveToDo()
        {
            return Ok("ToDo record created");
        }
    }
}
