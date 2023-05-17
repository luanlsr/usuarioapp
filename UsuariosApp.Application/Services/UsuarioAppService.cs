using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Application.Profiles;
using UsuariosApp.Domain.Entidades;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _service;
        private readonly IMapper _mapper;


        public UsuarioAppService(IUsuarioDomainService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public AutenticarResponseDTO Autenticar(AutenticarRequestDTO dto)
        {
            var usuario = _service.Autenticar(dto.Email, dto.Senha);
            return _mapper.Map<AutenticarResponseDTO>(usuario);
        }

        public CriarContaResponseDTO CriarConta(CriarContaRequestDTO dto)
        {
            var usuario = _mapper?.Map<Usuario>(dto);
            _service.CriarConta(usuario);

            return _mapper.Map<CriarContaResponseDTO>(usuario);
        }


        public RecuperarSenhaResponseDTO RecuperarSenha(RecuperarSenhaRequestDTO dto)
        {
            var usuario = _service.RecuperarSenha(dto.Email);
            return _mapper.Map<RecuperarSenhaResponseDTO>(usuario);
        }
        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
