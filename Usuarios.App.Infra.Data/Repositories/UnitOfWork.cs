using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.App.Infra.Data.Contexts;
using UsuariosApp.Domain.Interfaces.Repositorios;

namespace Usuarios.App.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dateContext;

        public UnitOfWork(DataContext dateContext)
        {
            _dateContext = dateContext;
        }

        public IUsuariosRepository? UsuarioRepository => new UsuariosRepository(_dateContext);

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
