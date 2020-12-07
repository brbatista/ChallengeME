using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Contratos
{
    public interface IGerenciadorMensagens
    {
        void AdicionarMensagem(string mensagem);
        List<string> ListarMensagens();
        bool PossuiMensagem();

    }
}
