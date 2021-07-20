using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestEFCore.Models;

namespace TestEFCore.Services.SqlImplementations
{
    public class Validations
    {
        private readonly TipoDocumentoService tipoDocumentoService;

        public Validations()
        {
            var efOptions = new DbContextOptionsBuilder<TestContext>()
                .UseSqlServer("Server=localhost,11433;Database=CarvajalTestDB;User Id=sa;Password=Pwd12345!;MultipleActiveResultSets=true")
                .Options;
            var db = new TestContext(efOptions);

            tipoDocumentoService = new TipoDocumentoService(db);
        }

        public async Task<bool> IsCCDocumentType()
        {
            return await tipoDocumentoService.ExistsDocumentTypeCC();
        }
    }
}
