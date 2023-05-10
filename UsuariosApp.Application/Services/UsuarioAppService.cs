using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Domain.Entidades;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _service;

        public UsuarioAppService(IUsuarioDomainService service)
        {
            _service = service;
        }

        public AutenticarResponseDTO Autenticar(AutenticarRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public CriarContaResponseDTO CriarConta(CriarContaRequestDTO dto)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                DataHoraCriacao = DateTime.Now,
            };

            _service.CriarConta(usuario);

            return new CriarContaResponseDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                DataHoraCriacao = usuario.DataHoraCriacao
            };
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
