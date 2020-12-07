using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.DTOs
{
    public class StatusPedidoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Pedido { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
