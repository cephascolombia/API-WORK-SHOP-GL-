using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Color;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/color")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
            => _colorService = colorService;


        [HttpPost("create")]
        [Authorize]
        public async Task<ApiResult> Create([FromBody] CreateColorRequest createColorRequest)
        {
            var colorDto = ObjectMapper.Map<CreateColorRequest, CreateColorDTO>(createColorRequest);

            var id = await _colorService.Insert(colorDto);

            return ApiResult.Ok(new { id });
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<ApiResult> Update([FromBody] EditColorRequest editColorRequest)
        {
            if (string.IsNullOrEmpty(editColorRequest.Codigo))
            {
                return ApiResult.Fail("Debe enviar el código del color");
            }

            var colorDto = ObjectMapper.Map<EditColorRequest, EditColorDTO>(editColorRequest);

            var id = await _colorService.Update(colorDto);

            return ApiResult.Ok(new { id });
        }

        [HttpDelete("delete/{codigo}")]
        [Authorize]
        public async Task<ApiResult> Delete(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return ApiResult.Fail("Debe enviar el código del color");
            }

            var id = await _colorService.Delete(codigo);

            return ApiResult.Ok(new { id });
        }
    }
}