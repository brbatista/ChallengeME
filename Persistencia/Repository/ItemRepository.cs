using Negocio.Contratos;
using Negocio.Models;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
