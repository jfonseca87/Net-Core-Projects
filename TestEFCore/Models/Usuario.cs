using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }

        public TipoDocumento TipoDocumento { get; set; }
    }
}
