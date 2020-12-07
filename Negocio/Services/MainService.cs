using FluentValidation;
using FluentValidation.Results;
using Negocio.Contratos;
using Negocio.Models;


namespace Negocio.Services
{
    public abstract class MainService
    {
        protected readonly IGerenciadorMensagens Gerenciador;

        protected MainService(IGerenciadorMensagens gerenciador)
        {
            Gerenciador = gerenciador;
        }

        protected void AdicionarMensagem(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AdicionarMensagem(error.ErrorMessage);
            }
        }

        protected void AdicionarMensagem(string mensagem)
        {
            Gerenciador.AdicionarMensagem(mensagem);
        }

        protected bool ValidarEntidade<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entidade
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            AdicionarMensagem(validator);

            return false;
        }
    }
}
