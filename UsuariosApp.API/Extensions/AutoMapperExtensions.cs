using UsuariosApp.Application.Profiles;

namespace UsuariosApp.API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

    }
}
