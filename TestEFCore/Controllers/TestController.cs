using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEFCore.CustomFilters;
using TestEFCore.Models;

namespace TestEFCore.Controllers
{
    [ApiController]
    [Route("api/Test")]
    public class TestController : ControllerBase
    {
        private readonly TestContext db;

        public TestController(TestContext _db)
        {
            db = _db;
        }

        [DocumentType]
        public async Task<IActionResult> GetDocumentTypes()
        {
            var documentTypes = await db.TipoDocumento.ToListAsync();
            return Ok(documentTypes);
        }
    }
}
