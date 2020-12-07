using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Models
{
    public class Pedido : Entidade
    {
        public List<Item> Itens { get; set; }
    }
}
