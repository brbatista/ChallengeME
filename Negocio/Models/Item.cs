using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Models
{
    public class Item : Entidade
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Qtd { get; set; }
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}
