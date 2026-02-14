using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Clase;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/clase")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IClaseService _claseService;

        public ClaseController(IClaseService claseService)
        {
            _claseService = claseService;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ApiResult> Create([FromBody] CreateClaseRequest request)
        {
            // Mapeamos de Request a DTO
            var dto = ObjectMapper.Map<CreateClaseRequest, CreateClaseDTO>(request);

            var id = await _claseService.Insert(dto);

            return ApiResult.Ok(new { id });
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<ApiResult> Update([FromBody] EditClaseRequest request)
        {
            if (string.IsNullOrEmpty(request.Codigo))
            {
                return ApiResult.Fail("El código de la clase es obligatorio para actualizar");
            }

            var dto = ObjectMapper.Map<EditClaseRequest, EditClaseDTO>(request);

            var id = await _claseService.Update(dto);

            return ApiResult.Ok(new { id });
        }

        [HttpDelete("delete/{codigo}")]
        [Authorize]
        public async Task<ApiResult> Delete(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return ApiResult.Fail("Debe proporcionar el código para eliminar");
            }

            var id = await _claseService.Delete(codigo);

            return ApiResult.Ok(new { id });
        }
    }
}