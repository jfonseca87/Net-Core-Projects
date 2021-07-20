using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.Models;

namespace TestCore
{
    public class TiposDocumentoService : ITiposDocumentoService
    {
        public IEnumerable<Listado> GetTiposDocumento()
        {
            throw new ArgumentNullException("There are not data tho show");

            List<Listado> tiposDocumento = new List<Listado>()
            {
                new Listado() { Clave = 1, Valor = "CC" },
                new Listado() { Clave = 1, Valor = "CE" },
                new Listado() { Clave = 1, Valor = "TI" },
                new Listado() { Clave = 1, Valor = "PA" },
                new Listado() { Clave = 1, Valor = "RC" }
            };

            return tiposDocumento;
        }
    }
}
