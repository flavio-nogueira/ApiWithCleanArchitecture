using ApiWithCleanArchitecture.Application.Interfaces;
using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using ApiWithCleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithCleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioService UsuarioService,ILogger<UsuarioController> logger)
        {
            _usuarioService = UsuarioService;
            _logger = logger;
        } 

        /// <summary>
        /// Incluir novo Usuario
        /// </summary>
        /// <param name="novoUsuarioView"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Incluir(NovoUsuarioView novoUsuarioView)
        {
            _logger.LogInformation("Foi requisicao de inclusao de novo usuario");
            var usuario = await _usuarioService.Incluir(novoUsuarioView);

            return Ok("Usuario incluido com sucesso");
        }

        /// <summary>
        /// Alterar Usuario
        /// </summary>
        /// <param name="alterarUsuarioView"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Alterar(AlterarUsuarioView alterarUsuarioView) 
        {
            var usuario = await _usuarioService.Alterar(alterarUsuarioView);
            if (usuario == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o Usuario");
            };

            return Ok("Usuario alterado com sucesso"); 
        }

        /// <summary>
        /// Excluir Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Excluir(int id)
        {
            await _usuarioService.Excluir(id);

            return NoContent();
        }
        
        /// <summary>
        /// Consultar Usuario pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Selecionar(int id)
        {
            var usuario = await _usuarioService.SelecionarAsync(id); 
            if (usuario == null)
            {
                return NotFound("Usuario nao localizado");
            };

            return Ok(usuario);
        }

        /// <summary>
        /// Listar todos usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> SelecionarTodos()
        {
            var usuario = await _usuarioService.SelecionarTodosAnync();
            if (usuario == null)
            {
                return NotFound("Usuario nao localizado");
            };

            return Ok(usuario);
        }
    }
}