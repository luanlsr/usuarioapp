using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Interfaces.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuariosRepository? UsuarioRepository { get; }
        void SaveChanges();
    }
}
