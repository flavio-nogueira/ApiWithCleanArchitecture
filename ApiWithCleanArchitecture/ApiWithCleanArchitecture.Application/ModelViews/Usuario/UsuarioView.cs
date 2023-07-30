using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Application.ModelViews.Usuario
{
    public  class UsuarioView
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        public string? LoginEmail { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
