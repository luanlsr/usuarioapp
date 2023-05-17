using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entidades;
using UsuariosApp.Domain.Exceptions.Usuarios;
using UsuariosApp.Domain.Interfaces.Repositorios;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Usuario Autenticar(string email, string senha)
        {
            var usuario = _unitOfWork.UsuarioRepository.Get(u => u.Email.Equals(email) && u.Senha.Equals(senha));
            if(usuario == null)
            {
                throw new AcessoNegadoException();
            }

            //TODO
            return usuario;
        }

        public Usuario RecuperarSenha(string email)
        {
            var usuario = _unitOfWork.UsuarioRepository.Get(u => u.Email.Equals(email));
            if (usuario == null)
            {
                throw new UsuarioNaoEncontradoException();
            }
            //TODO
            return usuario;
        }

        public void CriarConta(Usuario usuario)
        {
            var emailCadastrado = _unitOfWork.UsuarioRepository.Get(e => e.Email.Equals(usuario.Email));
            if(emailCadastrado != null)
            {
                throw new EmailJaCadastradoException();
            }

            _unitOfWork.UsuarioRepository.Add(usuario);
            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork.UsuarioRepository.Dispose();

        }
    }
}
