using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models
{
    public class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string NomTipoDocumento { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
