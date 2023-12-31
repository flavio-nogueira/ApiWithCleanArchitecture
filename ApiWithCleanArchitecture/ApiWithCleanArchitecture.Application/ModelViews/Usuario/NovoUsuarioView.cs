﻿using System.ComponentModel.DataAnnotations;

namespace ApiWithCleanArchitecture.Application.ModelViews.Usuario
{
    /// <summary>
    /// Objeto para inclusao de novo usuario
    /// </summary>
    public class NovoUsuarioView
    {
        /// <summary>
        /// Nome do usuario que tera acesso api
        /// </summary>
        /// <example>Flavio Nogueira</example>
        public string Nome { get; set; }

        /// <summary>
        /// Login de acesso a api se possivel usar primeira letra do nome e sobrenome
        /// </summary>
        /// <example>fnogueira</example>
        [EmailAddress]
        public string? LoginEmail { get; set; }

        /// <summary>
        /// Senha recomendamos usar senha forte
        /// </summary>
        /// <example>@E#$%345</example>
        public string? Senha { get; set; }

    }
}
