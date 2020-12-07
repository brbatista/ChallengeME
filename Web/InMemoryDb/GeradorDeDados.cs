using Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negocio.Models;

namespace Web.InMemoryDb
{
    public class GeradorDeDados
    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            using (var context = new ApiDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApiDbContext>>()))
            {
                if (context.Pedidos.Any())
                {
                    return;
                }

                var pedido1 = new Negocio.Models.Pedido
                {
                    Id = 1,
                    Itens = new List<Item> { new Negocio.Models.Item
                    {
                        Id = 1,
                        Descricao = "Item A",
                        PrecoUnitario = 10,
                        Qtd = 1
                    }, new Negocio.Models.Item
                    {
                        Id = 2,
                        Descricao = "Item B",
                        PrecoUnitario = 5,
                        Qtd = 2
                    }}
                };

                context.Pedidos.Add(pedido1);

                context.SaveChanges();
            }
        }
    }
}
