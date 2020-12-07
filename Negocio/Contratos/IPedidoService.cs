using Negocio.DTOs;
using System;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public interface IPedidoService : IDisposable
    {
        Task Adicionar(PedidoDto pedido);
        Task Atualizar(PedidoDto pedido);
        Task Remover(int id);
        Task<PedidoDto> ObterPorId(int id);
        Task<StatusResponseDto> ObterStatus(StatusPedidoDto statusPedido);
    }
}
