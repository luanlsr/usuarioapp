using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.App.Infra.Data.Contexts;
using UsuariosApp.Domain.Entidades;
using UsuariosApp.Domain.Interfaces.Repositorios;

namespace Usuarios.App.Infra.Data.Repositories
{
    public class UsuariosRepository : BaseRepository<Usuario, Guid>, IUsuariosRepository
    {
        private readonly DataContext _dataContext;

        public UsuariosRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
