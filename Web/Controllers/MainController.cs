using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Negocio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IGerenciadorMensagens GerenciadorMensagens;

        protected MainController(IGerenciadorMensagens gerenciadorMensagens)
        {
            GerenciadorMensagens = gerenciadorMensagens;
        }

        protected bool OperacaoValida()
        {
            return GerenciadorMensagens.PossuiMensagem();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = GerenciadorMensagens.ListarMensagens()
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) ExibirMensagemModelInvalida(modelState);
            return CustomResponse();
        }

        protected void ExibirMensagemModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                AdicionarmensagemErro(errorMsg);
            }
        }

        protected void AdicionarmensagemErro(string mensagem)
        {
            GerenciadorMensagens.AdicionarMensagem(mensagem);
        }
    }
}
