using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(x => x.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.UserName)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .HasIndex(x => x.UserName)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Nombre)
                 .HasMaxLength(20)
                .IsRequired(); 

            modelBuilder.Entity<Usuario>()
                 .Property(x => x.Email)
                 .HasMaxLength(100)
                 .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Telefono)
                .HasMaxLength(30)
                .HasDefaultValue(null);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Activo)
                .HasDefaultValue(true);
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
