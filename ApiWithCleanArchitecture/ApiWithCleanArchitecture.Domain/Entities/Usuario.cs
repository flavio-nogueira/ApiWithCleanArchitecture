﻿using System.ComponentModel.DataAnnotations;

namespace ApiWithCleanArchitecture.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        public string? LoginEmail { get; set; }

        public string? Senha { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }

    }
}
