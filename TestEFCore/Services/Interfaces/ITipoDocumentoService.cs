using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEFCore.Models;

namespace TestEFCore.Services.Interfaces
{
    public interface ITipoDocumentoService
    {
        Task<IEnumerable<TipoDocumento>> GetDocumentTypes();
    }
}
