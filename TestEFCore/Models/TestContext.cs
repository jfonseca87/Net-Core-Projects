using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestEFCore.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        { }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>()
                .HasKey("IdTipoDocumento");

            modelBuilder.Entity<Usuario>()
                .HasKey("IdUsuario");

            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.TipoDocumento)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.TipoIdentificacion);

        }
    }
}
