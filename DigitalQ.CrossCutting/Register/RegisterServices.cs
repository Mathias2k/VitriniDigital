using DigitalQ.Domain.Config;
using DigitalQ.Domain.Interfaces;
using DigitalQ.Domain.Interfaces.Business;
using DigitalQ.Domain.Interfaces.Repos;
using DigitalQ.Infra.Data.Db;
using DigitalQ.Infra.Data.Repositorios;
using DigitalQ.Service.Business;
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
