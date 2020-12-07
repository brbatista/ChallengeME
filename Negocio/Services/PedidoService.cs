using Negocio.Contratos;
using Negocio.DTOs;
using AutoMapper;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Negocio.Services
{
    public class PedidoService : MainService, IPedidoService
    {
        public readonly IPedidoRepository PedidoRepository;
        public readonly IItemRepository ItemRepository;
        public readonly IMapper Mapper;
        public PedidoService(IPedidoRepository pedidoRepository,
            IItemRepository itemRepository,
            IGerenciadorMensagens gerenciador,
            IMapper mapper) : base(gerenciador)
        {
            PedidoRepository = pedidoRepository;
            ItemRepository = itemRepository;
            Mapper = mapper;
        }

        public async Task Adicionar(PedidoDto pedido)
        {
            var pedidoEntity = Mapper.Map<Pedido>(pedido);
            await PedidoRepository.Adicionar(pedidoEntity);
        }

        public async Task Atualizar(PedidoDto pedido)
        {
            var pedidoEntity = Mapper.Map<Pedido>(pedido);
            await PedidoRepository.Atualizar(pedidoEntity);
        }

        public async Task<PedidoDto> ObterPorId(int id)
        {
            var pedido = await PedidoRepository.ObterPorId(id);
            var pedidoDto = Mapper.Map<PedidoDto>(pedido);

            return pedidoDto;
        }

        public async Task<StatusResponseDto> ObterStatus(StatusPedidoDto statusPedido)
        {
            var pedidoEntity = await ObterPorId(statusPedido.Pedido);
            var response = new StatusResponseDto { Pedido = statusPedido.Pedido };

            if (pedidoEntity == null)
            {
                response.Status.Add(Status.CodigoPedidoInvalido.Value);

                return response;
            }

            if (statusPedido.Status.Equals(Status.Reprovado.Value))
            {
                response.Status.Add(Status.Reprovado.Value);

                return response;
            }

            decimal valorTotalItens = pedidoEntity.Itens.Sum(item => item.PrecoUnitario * item.Qtd);
            int qtdTotalItens = pedidoEntity.Itens.Sum(item => item.Qtd);

            if (statusPedido.Status.Equals(Status.Aprovado.Value))
            {
                if (statusPedido.ItensAprovados == qtdTotalItens && statusPedido.ValorAprovado == valorTotalItens)
                {
                    response.Status.Add(Status.Aprovado.Value);
                    return response;
                }

                if (statusPedido.ValorAprovado < valorTotalItens)
                {
                    response.Status.Add(Status.AprovadoValorAMenor.Value);
                }

                if (statusPedido.ValorAprovado < valorTotalItens)
                {
                    response.Status.Add(Status.AprovadoValorAMaior.Value);
                }

                if (statusPedido.ItensAprovados < qtdTotalItens)
                {
                    response.Status.Add(Status.AprovadoQtdMenor.Value);
                }

                if (statusPedido.ItensAprovados > qtdTotalItens)
                {
                    response.Status.Add(Status.AprovadoQtdMaior.Value);
                }
            }

            return response;
        }

        public async Task Remover(int id)
        {
            await PedidoRepository.Excluir(id);
        }

        public void Dispose()
        {
            PedidoRepository.Dispose();
        }
    }
}
