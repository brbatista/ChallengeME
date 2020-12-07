using Microsoft.EntityFrameworkCore;
using Negocio.Contratos;
using Negocio.Models;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repository
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entidade, new()
    {
        protected readonly ApiDbContext Context;
        protected readonly DbSet<TEntidade> DbSet;

        protected Repository(ApiDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntidade>();
        }

        public virtual async Task Adicionar(TEntidade entity)
        {
            DbSet.Add(entity);
            await SalvarAlteracoes();
        }

        public virtual async Task Atualizar(TEntidade entity)
        {
            DbSet.Update(entity);
            await SalvarAlteracoes();
        }

        public virtual async Task Excluir(int id)
        {
            DbSet.Remove(new TEntidade { Id = id });
            await SalvarAlteracoes();
        }

        public virtual async Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> condicao)
        {
            return await DbSet.AsNoTracking().Where(condicao).ToListAsync();
        }

        public virtual async Task<TEntidade> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntidade>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> SalvarAlteracoes()
        {
            return await Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
