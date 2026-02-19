using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Tecnico;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/tecnico")]
    [ApiController]
    public class TecnicoController: ControllerBase
    {
        private readonly ITecnicoService _tecnicoService;

        public TecnicoController(ITecnicoService tecnicoService)
            => _tecnicoService = tecnicoService;


        [HttpPost("create")]
        [Authorize]
        public async Task<ApiResult> Create([FromBody] CreateTecnicoRequest createTecnicoRequest)
        {
            var tecnicoDto = ObjectMapper.Map<CreateTecnicoRequest, CreateTecnicoDTO>(createTecnicoRequest);
            var id = await _tecnicoService.Insert(tecnicoDto);
            return ApiResult.Ok(new { id });
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<ApiResult> Update([FromBody] EditTecnicoRequest editTecnicoRequest)
        {
            if (string.IsNullOrEmpty(editTecnicoRequest.CodigoTecnico))
            {
                return ApiResult.Fail("Debe enviar el código del técnico");
            }

            var tecnicoDto = ObjectMapper.Map<EditTecnicoRequest, EditTecnicoDTO>(editTecnicoRequest);
            var id = await _tecnicoService.Update(tecnicoDto);
            return ApiResult.Ok(new { id });
        }

        [HttpDelete("delete/{codigoTecnico}")]
        [Authorize]
        public async Task<ApiResult> Delete([FromRoute] string codigoTecnico)
        {
            if (string.IsNullOrEmpty(codigoTecnico))
            {
                return ApiResult.Fail("Debe enviar el código del técnico");
            }


            var id = await _tecnicoService.Delete(codigoTecnico);
            return ApiResult.Ok(new { id });
        }

        [HttpGet("get-all")]
        [Authorize]
        public async Task<ApiResult> GetAll([FromQuery] QueryTecnicoDTO query)
        {
            var result = await _tecnicoService.GetAll(query);
            return ApiResult.Ok(result);
        }
    }
}
