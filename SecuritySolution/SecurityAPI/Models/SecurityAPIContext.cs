using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SecurityAPI.Models
{
    public class SecurityAPIContext: DbContext
    {
        public SecurityAPIContext(): base("name=SecurityAPIContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        public DbSet<Menu> Menu { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolHasMenu> RolHasMenu { get; set; }
        public DbSet<TokenUsuario> TokenUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}