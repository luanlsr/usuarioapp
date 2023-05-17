using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Domain.Entidades;

namespace UsuariosApp.Application.Profiles
{
    public class DomainModelToDTOProfile : Profile
    {
            /// <summary>
            /// Mapeamento de DTOs para Modelos de domínio
            /// </summary>
            public DomainModelToDTOProfile()
            {
                CreateMap<Usuario, CriarContaResponseDTO>();
                CreateMap<Usuario, AutenticarResponseDTO>();
                CreateMap<Usuario, RecuperarSenhaResponseDTO>();
        }
    }
}
