using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Vehiculo;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/vehiculo")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;
        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet("getall")]
        [Authorize]
        public async Task<ApiResult> GetAll()
        {
            var vehiculos = await _vehiculoService.GetAll();
            var response = ObjectMapper.MapList<QueryVehiculoDTO, VehiculoResponse>(vehiculos);
            return ApiResult.Ok(response);
        }

        [HttpGet("getbyplaca/{placa}")]
        [Authorize]
        public async Task<ApiResult> GetByPlaca(string placa)
        {
            var vehiculo = await _vehiculoService.GetByPlaca(placa);
            var response = ObjectMapper.Map<QueryVehiculoDTO, VehiculoResponse>(vehiculo);
            return ApiResult.Ok(response);
        }

        [HttpGet("getbycodigo/{codigo}")]
        [Authorize]
        public async Task<ApiResult> GetByCodigo(string codigo)
        {
            var vehiculo = await _vehiculoService.GetByCodigo(codigo);
            var response = ObjectMapper.Map<QueryVehiculoDTO, VehiculoResponse>(vehiculo);
            return ApiResult.Ok(response);
        }

        [HttpGet("getbycliente/{cliente}")]
        [Authorize]
        public async Task<ApiResult> GetByCliente(string cliente)
        {
            var vehiculos = await _vehiculoService.GetByCliente(cliente);
            var response = ObjectMapper.MapList<QueryVehiculoDTO, VehiculoResponse>(vehiculos);
            return ApiResult.Ok(response);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ApiResult> Create([FromBody] CreateVehiculoRequest createVehiculoRequest)
        {
            var exist = await _vehiculoService.GetByPlaca(createVehiculoRequest.Placa);
            if (exist is not null)
            {
                return ApiResult.Fail("Ya existe un vehículo registrado con la placa proporcionada");
            }

            var vehiculo = ObjectMapper.Map<CreateVehiculoRequest, CreateVehiculoDTO>(createVehiculoRequest);

            var id = await _vehiculoService.Insert(vehiculo);
            return ApiResult.Ok(new { id });
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<ApiResult> Update([FromBody] EditVehiculoRequest editVehiculoRequest)
        {
            if (string.IsNullOrEmpty(editVehiculoRequest.Codigo))
            {
                return ApiResult.Fail("Debe enviar el código del vehículo");
            }

            var exist = await _vehiculoService.GetByCodigo(editVehiculoRequest.Codigo);
            if (exist is null)
            {
                return ApiResult.Fail("No existe un vehículo registrado con el código proporcionado");
            }

            var vehiculo = ObjectMapper.Map<EditVehiculoRequest, EditVehiculoDTO>(editVehiculoRequest);
            var id = await _vehiculoService.Update(vehiculo);
            return ApiResult.Ok(new { id });
        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<ApiResult> Delete([FromBody] List<string> codigos)
        {
            if (codigos == null || codigos.Count == 0)
                return ApiResult.Fail("Debe enviar al menos un código de vehículo");

            var id = await _vehiculoService.Delete(codigos);
            return ApiResult.Ok(new { id });
        }
    }
}
