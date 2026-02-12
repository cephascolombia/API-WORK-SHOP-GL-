using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Maestro;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/maestro")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private readonly IMaestroService _maestroService;

        public MaestroController(IMaestroService maestroService)
        {
            _maestroService = maestroService;
        }

        [HttpGet("getpaises")]
        [Authorize]
        public async Task<ApiResult> GetPaises()
        {
            var paises = await _maestroService.GetPaises();
            var response = ObjectMapper.MapList<QueryPaisDTO, PaisResponse>(paises);
            return ApiResult.Ok(response);
        }

        [HttpGet("getciudades")]
        [Authorize]
        public async Task<ApiResult> GetCiudades()
        {
            var ciudades = await _maestroService.GetCiudades();
            var response = ObjectMapper.MapList<QueryCiudadDTO, CiudadResponse>(ciudades);
            return ApiResult.Ok(response);
        }

        [HttpGet("getcolores")]
        [Authorize]
        public async Task<ApiResult> GetColores()
        {
            var colores = await _maestroService.GetColores();
            var response = ObjectMapper.MapList<QueryColorDTO, ColorResponse>(colores);
            return ApiResult.Ok(response);
        }

        [HttpGet("getclases")]
        [Authorize]
        public async Task<ApiResult> GetClases()
        {
            var clases = await _maestroService.GetClases();
            var response = ObjectMapper.MapList<QueryClaseDTO, ClaseResponse>(clases);
            return ApiResult.Ok(response);
        }

        [HttpGet("getcarrocerias")]
        [Authorize]
        public async Task<ApiResult> GetCarrocerias()
        {
            var carrocerias = await _maestroService.GetCarrocerias();
            var response = ObjectMapper.MapList<QueryCarroceriaDTO, CarroceriaResponse>(carrocerias);
            return ApiResult.Ok(response);
        }

        [HttpGet("getmarcas")]
        [Authorize]
        public async Task<ApiResult> GetMarcas()
        {
            var marcas = await _maestroService.GetMarcas();
            var response = ObjectMapper.MapList<QueryMarcaDTO, MarcaResponse>(marcas);
            return ApiResult.Ok(response);
        }
    }
}
