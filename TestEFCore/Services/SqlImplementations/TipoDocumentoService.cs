using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestEFCore.Models;
using TestEFCore.Services.Interfaces;

namespace TestEFCore.Services.SqlImplementations
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly TestContext db;

        public TipoDocumentoService(TestContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<TipoDocumento>> GetDocumentTypes()
        {
            return await db.TipoDocumento.ToListAsync();
        }

        public async Task<bool> ExistsDocumentTypeCC()
        {
            return await db.TipoDocumento.Where(x => x.NomTipoDocumento.Equals("CC")).AnyAsync();
        }
    }
}
