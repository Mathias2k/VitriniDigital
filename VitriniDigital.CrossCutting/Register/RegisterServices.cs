﻿using VitriniDigital.Domain.Config;
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

            services.AddTransient<IEstabelecimentoService, EstabelecimentoService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<IImagemService, ImagemService>();
            services.AddTransient<ILinkService, LinkService>();

            services.AddTransient<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
            services.AddTransient<IImagemRepository, ImagemRepository>();
            services.AddTransient<ILinkRepository, LinkRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            services.Configure<ApiConfiguration>(configuration.GetSection("ApiConfiguration"));
            services.AddScoped(cfg => cfg.GetService<IOptions<ApiConfiguration>>().Value);

            return services;
        }
    }
}
