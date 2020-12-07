using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task Adicionar(TEntidade entidade);
        Task<TEntidade> ObterPorId(int id);
        Task<List<TEntidade>> ObterTodos();
        Task Excluir(int id);
        Task Atualizar(TEntidade entidade);
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> condicao);
        Task<int> SalvarAlteracoes();
    }
}
