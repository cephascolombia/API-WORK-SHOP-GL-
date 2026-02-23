using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.Application.Services.Revision;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RevisionController : ControllerBase
    {
        private readonly IRevisionService _revisionService;

        public RevisionController(IRevisionService revisionService)
        {
            _revisionService = revisionService;
        }

        [HttpGet("getbyestado_id")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> GetAll([FromQuery] int estado = 0, [FromQuery] int id = 0)
        {
            var result = await _revisionService.GetAllAsync(estado, id);
            return Ok(ApiResult.Ok(result));
        }

        [HttpGet("{id}/checklist/{idSistema}")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> GetChecklist(int id, string idSistema)
        {
            var result = await _revisionService.GetChecklistAsync(id, idSistema);
            return Ok(ApiResult.Ok(result));
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> Insert([FromBody] CreateRevisionRequest request)
        {
            var newId = await _revisionService.InsertAsync(request);
            return Ok(ApiResult.Ok(new { Id = newId }));
        }

        [HttpPut("{id}/Update")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> Update(int id, [FromBody] CreateRevisionRequest request)
        {
            await _revisionService.UpdateAsync(id, request);
            return Ok(ApiResult.Ok());
        }

        [HttpPatch("{id}/anular")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> Anular(int id)
        {
            await _revisionService.AnularAsync(id);
            return Ok(ApiResult.Ok());
        }

        [HttpGet("{id}/diagnostico")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> GetDiagnostico(int id)
        {
            var result = await _revisionService.GetDiagnosticoAsync(id);
            return Ok(ApiResult.Ok(result));
        }

        [HttpPost("{id}/diagnostico")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> UpsertDiagnostico(int id, [FromBody] UpsertDiagnosticoRequest request)
        {
            await _revisionService.UpsertDiagnosticoAsync(id, request);
            return Ok(ApiResult.Ok());
        }

        [HttpGet("{id}/diagnostico/impresion")]
        [Authorize]
        public async Task<ActionResult<ApiResult>> GetDiagnosticoImpresion(int id)
        {
            var result = await _revisionService.GetDiagnosticoImpresionAsync(id);
            return Ok(ApiResult.Ok(result));
        }
    }
}
