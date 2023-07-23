
using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using FluentValidation;

namespace ApiWithCleanArchitecture.Application.Validation
{
    public class NovoUsuarioValidator : AbstractValidator<NovoUsuarioView>
    {
        public NovoUsuarioValidator()
        {   
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(x => x.Login).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(x => x.Senha).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100);
        }
    }
}

