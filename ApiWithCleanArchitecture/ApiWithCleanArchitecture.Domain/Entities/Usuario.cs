using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
