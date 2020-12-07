using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class Status
    {
        private Status(string value) { Value = value; }
        public string Value { get; set; }

        public static Status Aprovado { get { return new Status("APROVADO"); } }
        public static Status Reprovado { get { return new Status("REPROVADO"); } }
        public static Status AprovadoQtdMaior { get { return new Status("APROVADO_QTD_MAIOR"); } }
        public static Status AprovadoQtdMenor { get { return new Status("APROVADO_QTD_MENOR"); } }
        public static Status AprovadoValorAMaior { get { return new Status("APROVADO_VALOR_A_MAIOR"); } }
        public static Status AprovadoValorAMenor { get { return new Status("APROVADO_VALOR_A_MENOR"); } }
        public static Status CodigoPedidoInvalido { get { return new Status("CODIGO_PEDIDO_INVALIDO"); } }
    }
}
