using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Application.ModelViews.Usuario
{
    public class LoginUsuarioView
    {
        //[Required(ErrorMessage = "User Name é obrigatório!")]
        public string? Email { get; set; }

       // [Required(ErrorMessage = "Password é obrigatório!")]
        public string? Senha { get; set; }
    }
}
