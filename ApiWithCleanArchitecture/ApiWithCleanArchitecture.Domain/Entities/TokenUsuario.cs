using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Domain.Entities
{
    public  class TokenUsuario 
    {
        public string? Token { get; set; }
        public DateTime DataValidade { get; set; } 
    }
}
