using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecurityAPI.Models
{
    [Table("TokenUsuario")]
    public class TokenUsuario
    {
        [Key]
        public int IdTokenUsuario { get; set; }
        public string Token { get; set; }
        public string Acceso { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}