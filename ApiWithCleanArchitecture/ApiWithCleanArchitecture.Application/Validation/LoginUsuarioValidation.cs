using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Application.Validation
{
     public class LoginUsuarioValidation : AbstractValidator<LoginUsuarioView>
    {
        public LoginUsuarioValidation()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Senha).NotNull().NotEmpty();
          
        }
    }
}
