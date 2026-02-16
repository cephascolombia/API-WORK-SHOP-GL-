using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Marca;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
            => _marcaService = marcaService;


        [HttpPost("create")]
        [Authorize]
        public async Task<ApiResult> Create([FromBody] CreateMarcaRequest createMarcaRequest)
        {
            var marcaDto = ObjectMapper.Map<CreateMarcaRequest, CreateMarcaDTO>(createMarcaRequest);
            var id = await _marcaService.Insert(marcaDto);
            return ApiResult.Ok(new { id });
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<ApiResult> Update([FromBody] EditMarcaRequest request)
        {
            if (string.IsNullOrEmpty(request.codMarV))
            {
                return ApiResult.Fail("Debe enviar el código de la marca");
            }
            var marcaDto = ObjectMapper.Map<EditMarcaRequest, EditMarcaDTO>(request);
            var id = await _marcaService.Update(marcaDto);
            return ApiResult.Ok(new { id });
        }


        [HttpDelete("delete/{codigo}")]
        [Authorize]
        public async Task<ApiResult> Delete(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return ApiResult.Fail("Debe enviar el código de la marca");
            }

            var id = await _marcaService.Delete(codigo);

            return ApiResult.Ok(new { id });


        }
    }
}
