using ApiWithCleanArchitecture.Application.Interfaces;
using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithCleanArchitecture.Api.Controllers
{

     [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<HomeController> _logger;


        public HomeController(IUsuarioService UsuarioService, ILogger<HomeController> logger) 
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
        //[ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(Usuario), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Incluir(NovoUsuarioView novoUsuarioView)
        {
            _logger.LogInformation("Foi requisicao de inclusao de novo usuario");
            var usuario = await _usuarioService.Incluir(novoUsuarioView);

            return Ok("Usuario incluido com sucesso");
        }
    }

}