using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Application.Validation
{
     public class AlteraUsuarioValidator : AbstractValidator<AlterarUsuarioView>
    {
        public AlteraUsuarioValidator()
        {
            // incluindo as validacoes no Novo Usuario
            Include(new NovoUsuarioValidator());
            //Se necessario acrescentar validacoes especificas para Alterar Usuario
        }
    }
}
