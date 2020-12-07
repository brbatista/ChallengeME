using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.DTOs
{
    public class StatusResponseDto
    {
        public StatusResponseDto()
        {
            Status = new List<string>();
        }
        public int Pedido { get; set; }

        public List<string> Status { get; set; }
    }
}
