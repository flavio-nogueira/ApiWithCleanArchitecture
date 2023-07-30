using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Application.ModelViews.Usuario
{
    public  class TokenView
    {
        public string? Token { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
