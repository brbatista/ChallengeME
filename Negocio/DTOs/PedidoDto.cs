using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.DTOs
{
    public class PedidoDto
    {
        public int Pedido { get; set; }

        [Required, MinLength(1, ErrorMessage = "É obrigatório pelo menos um item por pedido")]
        public List<ItemDto> Itens { get; set; }
    }
}
