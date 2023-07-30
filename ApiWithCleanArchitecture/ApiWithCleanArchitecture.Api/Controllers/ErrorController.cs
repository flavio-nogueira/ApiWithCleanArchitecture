using ApiWithCleanArchitecture.Application.ModelViews.Error;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithCleanArchitecture.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("Error")]
        public ErrorResponse Error()
        {
            var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var exception = contexto?.Error;

            // e possivel tratar cada exception de devolver de acordo com statuscode

            Response.StatusCode = 500;

            var IdError = HttpContext.TraceIdentifier;

            return new ErrorResponse(IdError);

        }

    }
}