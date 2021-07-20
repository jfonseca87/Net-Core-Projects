using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudAPI.Controllers
{
    [ApiController]
    [Route("api/audit")]
    public class AuditController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAudit()
        {
            return Ok("Data from audit");
        }

        [HttpPost]
        public IActionResult SaveAudit()
        {
            return Ok("Audit record created");
        }
    }
}
