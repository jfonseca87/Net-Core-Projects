using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationTest.Validations
{
    public class ConfValidation
    {
        public string NombrePropiedad { get; set; }
        public bool NotEmpty { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool ValidRegex { get; set; }
        public string Regex { get; set; }
        public List<string> ListaExcepcionPersonalizada { get; set; }
        public bool IsEmail { get; set; }
        public bool IsList { get; set; }
    }
}
