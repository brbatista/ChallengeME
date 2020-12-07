using Negocio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Mensagens
{
    public class GerenciadorMensagens : IGerenciadorMensagens
    {
        public List<string> Mensagens;

        public GerenciadorMensagens()
        {
            Mensagens = new List<string>();
        }

        public void AdicionarMensagem(string mensagem)
        {
            Mensagens.Add(mensagem);
        }

        public List<string> ListarMensagens()
        {
            return Mensagens;
        }

        public bool PossuiMensagem()
        {
            return Mensagens.Any();
        }
    }
}
