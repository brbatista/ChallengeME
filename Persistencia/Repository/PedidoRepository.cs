using Microsoft.EntityFrameworkCore;
using Negocio.Contratos;
using Negocio.Models;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApiDbContext context) : base(context) { }


        public override async Task<Pedido> ObterPorId(int id)
        {
            return await DbSet.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<List<Pedido>> ObterTodos()
        {
            return await DbSet.Include(p=> p.Itens).ToListAsync();
        }
    }
}

