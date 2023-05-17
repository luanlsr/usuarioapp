using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Helpers;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Domain.Entidades;

namespace UsuariosApp.Application.Profiles
{
    public class DTOToDomainModelProfile : Profile
    {
        /// <summary>
        /// Mapeamento de DTOs para Modelos de domínio
        /// </summary>
        public DTOToDomainModelProfile()
        {
            CreateMap<CriarContaRequestDTO, Usuario>()
                .AfterMap((dto, model) =>
                {
                    model.Id = Guid.NewGuid();
                    model.DataHoraCriacao = DateTime.Now;
                    model.Senha = SHA1Helper.Encrypt(dto.Senha);
                });
        }
    }
}
