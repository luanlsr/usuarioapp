using Microsoft.EntityFrameworkCore;
using Usuarios.App.Infra.Data.Contexts;

namespace UsuariosApp.API.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("UsuariosApp");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

    }
}
