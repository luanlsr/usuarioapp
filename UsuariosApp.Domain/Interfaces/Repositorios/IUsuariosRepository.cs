using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entidades;

namespace UsuariosApp.Domain.Interfaces.Repositorios
{
    public interface IUsuariosRepository : IBaseRepository<Usuario, Guid>
    {
    }
}
