using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.DTOs
{
    public class StatusResponseDto
    {
        public int Pedido { get; set; }

        public List<string> Status { get; set; }
    }
}
