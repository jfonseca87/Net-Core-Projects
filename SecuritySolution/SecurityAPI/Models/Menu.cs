using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecurityAPI.Models
{
    [Table("Menu")]
    public class Menu
    {
        public Menu()
        {
            RolHasMenu = new List<RolHasMenu>();
        }

        [Key]
        public int IdMenu { get; set; }
        public string NomMenu { get; set; }
        public string URLMenu { get; set; }

        public List<RolHasMenu> RolHasMenu { get; set; }
    }
}