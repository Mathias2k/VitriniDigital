using VitriniDigital.Domain.Config;
using VitriniDigital.Domain.Interfaces;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Infra.Data.Db;
using VitriniDigital.Infra.Data.Repositorios;
using VitriniDigital.Service.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Digital.CrossCutting.Register
{
    public static class RegisterServices
    {
        public static IServiceCollection AddRegisters(this IServiceCollection services, 
                                                           IConfiguration configuration)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.Configure<ApiConfiguration>(configuration.GetSection("ApiConfiguration"));
            services.AddScoped(cfg => cfg.GetService<IOptions<ApiConfiguration>>().Value);

            return services;
        }
    }
}
