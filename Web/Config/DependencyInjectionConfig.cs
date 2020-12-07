using Microsoft.Extensions.DependencyInjection;
using Negocio.Contratos;
using Negocio.Mensagens;
using Negocio.Services;
using Persistencia.Context;
using Persistencia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiDbContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<IGerenciadorMensagens, GerenciadorMensagens>();

            services.AddScoped<IPedidoService, PedidoService>();

            return services;
        }
    }
}
