using Microsoft.Extensions.DependencyInjection;
using ReceitaWSAPI.Application.Interfaces;
using ReceitaWSAPI.Application.Services;
using ReceitaWSAPI.Data.Repository;
using ReceitaWSAPI.Domain.Interfaces;

namespace ReceitaWSAPI.Infra.CrossCutting.IoC.Geral
{
    public static class GeralInjectorServiceConfig
    {

        public static void RegisterGeralInjectorServices(this IServiceCollection services)
        {
            // services

            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();

            // repositories

            services.AddScoped<ILoginRespository, LoginRepository>();
            services.AddScoped<IPedidoRespository, PedidoRepository>();
        }
    }
}
