using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Application.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioAppService? _usuarioAppService;
           public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Autenticação de usuários
        /// </summary>
        [HttpPost]
        [Route("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponseDTO), StatusCodes.Status200OK)]
        public IActionResult Autenticar(AutenticarRequestDTO usuarioDto)
        {
            return Ok(_usuarioAppService.Autenticar(usuarioDto));
        }
        
        /// <summary>
        /// Criação de conta de usuários
        /// </summary>
        [HttpPost]
        [Route("criar-conta")]
        [ProducesResponseType(typeof(CriarContaResponseDTO), StatusCodes.Status201Created)]
        public IActionResult CriarConta(CriarContaRequestDTO usuarioDto) 
        {
            return Ok(_usuarioAppService.CriarConta(usuarioDto));
        }
    }
}
