using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class Pedido : Entidade
    {
        public Pedido()
        {
            Itens = new List<Item>();
        }
        public List<Item> Itens { get; set; }
    }
}
