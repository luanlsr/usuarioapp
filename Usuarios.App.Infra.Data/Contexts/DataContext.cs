using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        DbSet<Usuario>? Usuarios { get; set; }

        //protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("UsuariosApp"));
        //    //optionsBuilder.UseSqlServer();

        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfigurations());
        }

    }
}
