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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(x => x.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.UserName)
                .HasMaxLength(20)
                .IsRequired();

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
                .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Activo)
                .HasDefaultValue(true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;initial catalog=ExamenTecnicoCOA;Integrated Security=true;");
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
