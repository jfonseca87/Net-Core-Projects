using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecurityAPI.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario()
        {
            TokenUsuario = new List<TokenUsuario>();
        }

        [Key]
        public int IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }

        public Rol Rol { get; set; }
        public List<TokenUsuario> TokenUsuario { get; set; }
    }
}