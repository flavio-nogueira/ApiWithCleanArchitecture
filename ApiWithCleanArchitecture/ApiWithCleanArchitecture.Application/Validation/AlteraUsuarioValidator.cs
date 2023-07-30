using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using FluentValidation;

namespace ApiWithCleanArchitecture.Application.Validation
{
    public class AlteraUsuarioValidator : AbstractValidator<AlterarUsuarioView>
    {
        public AlteraUsuarioValidator()
        {
            // incluindo as validacoes no Novo Usuario
          //  Include(new NovoUsuarioValidator());
            //Se necessario acrescentar validacoes especificas para Alterar Usuario
        }
    }
}
