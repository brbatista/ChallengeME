using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.DTOs
{
    public class ItemDto
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal PrecoUnitario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Qtd { get; set; }
    }
}
