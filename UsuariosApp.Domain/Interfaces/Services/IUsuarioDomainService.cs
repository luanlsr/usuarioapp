using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entidades;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IDisposable
    {
        void CriarConta(Usuario usuario);
        //void Autenticar(Usuario usuario);
    }
}
