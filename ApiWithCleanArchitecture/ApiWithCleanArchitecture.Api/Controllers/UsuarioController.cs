using ApiWithCleanArchitecture.Application.Interfaces;
using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using ApiWithCleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;
using System.Diagnostics.Eventing.Reader;

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

            _logger.LogInformation("Objeto recebido {@novoUsuarioView}", novoUsuarioView);
            NovoUsuarioView usuario;
            using (Operation.Time("Tempo de inclusao do Cliente"))
            {
                _logger.LogInformation("Foi iniciado requisicao de inclusao de novo usuario");
                usuario = await _usuarioService.Incluir(novoUsuarioView);
            }
          
            return Ok("Usuario incluido com sucesso");
            _logger.LogInformation("Finalizado requisicao de inclusao de novo usuario com sucesso ");
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
            _logger.LogInformation("Foi iniciado requisicao de alteracao do usuario");
            var usuario = await _usuarioService.Alterar(alterarUsuarioView);
            if (usuario == null)
            {
                _logger.LogInformation("Ocorreu um erro ao alterar o Usuario");
                return BadRequest("Ocorreu um erro ao alterar o Usuario");
            };
            _logger.LogInformation("Foi finalizado requisicao de alteracao usuario");
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
        public async Task<ActionResult> Excluir(string login)
        {
            _logger.LogInformation("Foi iniciado requisicao de exclusao do usuario");
            await _usuarioService.Excluir(login);
            _logger.LogInformation("Foi finalizado requisicao de exclusao do usuario");

            return NoContent();
        }


        /// <summary>
        /// Logar na na api com usuario e senha
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login(string login, string senha  )
        {
            _logger.LogInformation("Foi iniciado requisicao login  usuario ");
            var usuario = await _usuarioService.LoginAsync(login,senha); 
            if (usuario == null)
            {
                _logger.LogInformation("Foi finalizado requisicao de pesquisa do usuario por id porem nao encontrado");
                return Unauthorized();
            }
            else
            {
                 if (usuario.Logado == false)
                 {
                    return Unauthorized();
                    _logger.LogInformation(usuario.Aviso);
                 }
                 else
                {
                    _logger.LogInformation("Foi finalizado requisicao login  usuario ");
                    return Ok(usuario);
                }

            }
           
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
            throw new Exception("Erro teste");
            _logger.LogInformation("Foi iniciado requisicao listagem dos usuarios");
            var usuario = await _usuarioService.SelecionarTodosAnync();
            if (usuario == null)
            {
                return NotFound("Usuario nao localizado");
                _logger.LogInformation("Foi finalizado requisicao listagem dos usuarios , porem sem registros");
            };
            _logger.LogInformation("Foi iniciado requisicao de alteracao do usuario");
            return Ok(usuario);
        }
    }
}