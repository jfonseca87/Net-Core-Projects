using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecurityAPI.Models
{
    [Table("RolHasMenu")]
    public class RolHasMenu
    {
        [Key]
        public int IdMenuHasRol { get; set; }
        public int IdRol { get; set; }
        public int IdMenu { get; set; }

        public Rol Rol { get; set; }
        public Menu Menu { get; set; }
    }
}