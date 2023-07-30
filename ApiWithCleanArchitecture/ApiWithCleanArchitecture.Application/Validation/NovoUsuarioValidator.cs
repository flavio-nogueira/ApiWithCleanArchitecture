using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using ApiWithCleanArchitecture.Domain.Interfaces;
using FluentValidation;

namespace ApiWithCleanArchitecture.Application.Validation
{
    public class NovoUsuarioValidator : AbstractValidator<NovoUsuarioView>
    {
        private readonly IUsuarioRepository _repository;
        public NovoUsuarioValidator(IUsuarioRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(x => x.LoginEmail)
                .NotNull().NotEmpty()
                .Must(LoginEmail => !ExisteNaBase(LoginEmail)) // Change to synchronous method here
                .WithMessage("Usuario já cadastrado");
            RuleFor(x => x.Senha).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100);
        }

        private bool ExisteNaBase(string loginEmail)
        {
            return Task.Run(async () => await _repository.ValidarLoginAsync(loginEmail)).Result; // Use Task.Run to call the asynchronous method synchronously
        }
    }
}
