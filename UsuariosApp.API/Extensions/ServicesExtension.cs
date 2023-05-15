using Usuarios.App.Infra.Data.Contexts;
using Usuarios.App.Infra.Data.Repositories;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Services;
using UsuariosApp.Domain.Interfaces.Repositorios;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;

namespace UsuariosApp.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
