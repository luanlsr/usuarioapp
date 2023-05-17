using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Test.Helpers;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using Xunit;

namespace UsuarioApp.Test
{

    public class UsuariosTest
    {
        [Fact]
        public async Task<CriarContaRequestDTO> Usuarios_Post_CriarConta_Returns_Created()
        {
            // Arrange(Preparar o teste)
            var faker = new Faker("pt_BR");
            var request = new CriarContaRequestDTO 
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email,
                Senha = /*faker.Internet.Password(10)*/ "@Teste123"
            };

            var content = TestHelper.CreateContent(request);

            // Act(Rodar o teste) 
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);
            var response = TestHelper.ReadResponse<CriarContaResponseDTO> (result);

            // Assert(Verificar as asserções)
            result.StatusCode.Should().Be(HttpStatusCode.Created);

            response.Id.Should().NotBeEmpty();
            response.Nome.Should().Be(faker.Person.FullName);
            response.Email.Should().Be(faker.Person.Email);
            response.DataHoraCriacao.Should().NotBeNull();

            return request;
        }

        [Fact]
        public async Task Usuarios_Post_CriarConta_Returns_BadRequest()
        {
            // Arrange(Preparar o teste)
            var usuario = await Usuarios_Post_CriarConta_Returns_Created();

            var request = new CriarContaRequestDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);

            // Act(Rodar o teste) 
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);
            //var response = TestHelper.ReadResponse<CriarContaResponseDTO>(result);

            // Assert(Verificar as asserções)
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            //response.Id.Should().NotBeEmpty();
            //response.Nome.Should().Be(usuario.Nome);
            //response.Email.Should().Be(usuario.Email);
            //response.DataHoraCriacao.Should().NotBeNull();
        }

        [Fact]
        public async Task Usuarios_Post_CriarConta_SenhaInvalida_Returns_BadRequest()
        {
            // Arrange(Preparar o teste)
            var usuario = await Usuarios_Post_CriarConta_Returns_Created();

            var request = new CriarContaRequestDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = "123456"
            };

            var content = TestHelper.CreateContent(request);

            // Act(Rodar o teste) 
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);
            //var response = TestHelper.ReadResponse<CriarContaResponseDTO>(result);

            // Assert(Verificar as asserções)
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            //response.Id.Should().NotBeEmpty();
            //response.Nome.Should().Be(usuario.Nome);
            //response.Email.Should().Be(usuario.Email);
            //response.DataHoraCriacao.Should().NotBeNull();
        }

        [Fact]
        public async Task Usuarios_Post_CriarConta_EmailInvalido_Returns_BadRequest()
        {
            // Arrange(Preparar o teste)
            var usuario = await Usuarios_Post_CriarConta_Returns_Created();

            var request = new CriarContaRequestDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);

            // Act(Rodar o teste) 
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);
            //var response = TestHelper.ReadResponse<CriarContaResponseDTO>(result);

            // Assert(Verificar as asserções)
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            //response.Id.Should().NotBeEmpty();
            //response.Nome.Should().Be(usuario.Nome);
            //response.Email.Should().Be(usuario.Email);
            //response.DataHoraCriacao.Should().NotBeNull();
        }

        [Fact]
        public async Task Usuarios_Post_Autenticar_Returns_OK()
        {
            // Arrange(Preparar o teste)
            var usuario = await Usuarios_Post_CriarConta_Returns_Created();

            var request = new AutenticarRequestDTO
            {
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            // Act(Rodar o teste) 
            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/autenticar", content);
            var response = TestHelper.ReadResponse<AutenticarResponseDTO>(result);

            // Assert(Verificar as asserções)
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Email.Should().Be(usuario.Email);
            response.AccessToken.Should().NotBeNullOrEmpty();
            response.DataHoraExpiracao.Should().NotBeNull();
        }

        [Fact]
        public async Task Usuarios_Post_Autenticar_Returns_Unauthorized()
        {
            // Arrange(Preparar o teste)
            var faker = new Faker("pt_BR");
            var request = new CriarContaRequestDTO
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email,
                Senha = /*faker.Internet.Password(10)*/ "@Teste123"
            };
            // Act(Rodar o teste) 
            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/autenticar", content);
            var response = TestHelper.ReadResponse<AutenticarResponseDTO>(result);

            // Assert(Verificar as asserções)
            result.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }


        [Fact(Skip = "Não implementado.")]
        public void Usuarios_Post_RecuperarSenha_Returns_Ok()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void Usuarios_Post_RecuperarSenha_Returns_NotFound()
        {

        }

    }
}
