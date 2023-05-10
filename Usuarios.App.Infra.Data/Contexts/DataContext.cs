using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.App.Infra.Data.Configurations;
using UsuariosApp.Domain.Entidades;

namespace Usuarios.App.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        DbSet<Usuario>? Usuarios { get; set; }

        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UsuarioApp");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfigurations());
        }

    }
}
