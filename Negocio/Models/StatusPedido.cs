using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class StatusPedido
    {
        public StatusPedido()
        {
            Status = new List<string>();
        }

        public int Pedido { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public List<string> Status { get; set; }
    }
}
