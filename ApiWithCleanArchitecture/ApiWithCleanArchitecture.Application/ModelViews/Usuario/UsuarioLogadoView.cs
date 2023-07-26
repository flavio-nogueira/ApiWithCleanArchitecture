using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Application.ModelViews.Usuario
{
    public  class UsuarioLogadoView
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public bool Logado { get; set; }
        public DateTime DataHoraLogin { get; set; }
        public string Aviso { get; set; }
    }
}
