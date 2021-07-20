using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityAPI.Models
{
    [Table("Rol")]
    public class Rol
    {
        public Rol()
        {
            RolHasMenu = new Collection<RolHasMenu>();
        }

        [Key]
        public int IdRol { get; set; }
        public string NomRol { get; set; }

        public Collection<RolHasMenu> RolHasMenu { get; set; }
    }
}