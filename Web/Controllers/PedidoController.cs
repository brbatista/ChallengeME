using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Contratos;
using Negocio.DTOs;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : MainController
    {
        private readonly IPedidoService PedidoService;
        public PedidoController(IGerenciadorMensagens gerenciadorMensagens, IPedidoService pedidoService) : base(gerenciadorMensagens)
        {
            PedidoService = pedidoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDto>> ObterPorId(int id)
        {
            var pedidoDto = await PedidoService.ObterPorId(id);

            if (pedidoDto == null) return NotFound();

            return Ok(pedidoDto);
        }

        [HttpPost("status")]
        public async Task<ActionResult<StatusResponseDto>> ObterStatus(StatusPedidoDto statusPedido)
        {
            var statusPedidoDto = await PedidoService.ObterStatus(statusPedido);

            return statusPedidoDto;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDto>> Adicionar([FromBody] PedidoDto pedido)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await PedidoService.Adicionar(pedido);

            return Created("Adicionar", pedido);
        }

        [HttpPut]
        public async Task<ActionResult<PedidoDto>> Atualizar([FromBody] PedidoDto pedido)
        {
            if (pedido.Pedido == 0)
            {
                AdicionarmensagemErro("O id informado é inválido");
                return CustomResponse(pedido);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await PedidoService.Atualizar(pedido);

            return CustomResponse(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoDto>> Excluir(int id)
        {
            var pedido = await PedidoService.ObterPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }

            await PedidoService.Remover(id);
            return CustomResponse(pedido);
        }
    }
}
