using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Sistema;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaService _sistemaService;

        public SistemaController(ISistemaService sistemaService)
        {
            _sistemaService = sistemaService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApiResult>> GetSistemas([FromQuery] QuerySistemaDTO query)
        {
            var result = await _sistemaService.GetSistemasAsync(query);
            return Ok(ApiResult.Ok(result));
        }

        [HttpGet("{codSistema}/componentes")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> GetComponentesBySistema(string codSistema)
        {
            var result = await _sistemaService.GetComponentesBySistemaAsync(codSistema);
            return Ok(ApiResult.Ok(result));
        }

        [HttpGet("buscar")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> BuscarComponentes([FromQuery] string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                return BadRequest(ApiResult.Fail("El criterio de búsqueda es requerido."));
            }

            var result = await _sistemaService.BuscarComponentesAsync(criterio);
            return Ok(ApiResult.Ok(result));
        }
    }
}
