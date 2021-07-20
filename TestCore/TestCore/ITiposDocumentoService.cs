using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.Models;

namespace TestCore
{
    public interface ITiposDocumentoService
    {
        IEnumerable<Listado> GetTiposDocumento();
    }
}
