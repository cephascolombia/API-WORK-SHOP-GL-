using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Cliente;
using WorkShopGL.Shared.Exeptions;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("getall")]
        [Authorize]
        public async Task<ApiResult> GetAll()
        {
            var clientes = await _clienteService.GetAll();
            var response = ObjectMapper.MapList<QueryClienteDTO, ClienteResponse>(clientes);
            return ApiResult.Ok(response);
        }

        [HttpGet("getbynit/{nit}")]
        [Authorize]
        public async Task<ApiResult> GetByNit(string nit)
        {
            var cliente = await _clienteService.GetByNit(nit);
            var response = ObjectMapper.Map<QueryClienteDTO, ClienteResponse>(cliente);
            return ApiResult.Ok(response);
        }

        [HttpGet("getbycodigo/{codigo}")]
        [Authorize]
        public async Task<ApiResult> GetByCodigo(string codigo)
        {
            var cliente = await _clienteService.GetByCodigo(codigo);
            var response = ObjectMapper.Map<QueryClienteDTO, ClienteResponse>(cliente);
            return ApiResult.Ok(response);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ApiResult> Create([FromBody] CreateClienteRequest createClienteRequest)
        {
            var exists = await _clienteService.GetByNit(createClienteRequest.Nit);

            if (exists is not null) 
            {
                throw new BusinessException("Ya existe un cliente registrado con el NIT proporcionado", 409);
            }

            var cliente = ObjectMapper.Map<CreateClienteRequest,CreateClienteDTO>(createClienteRequest);

            var id = await _clienteService.Insert(cliente);
            return ApiResult.Ok(new { id });
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<ApiResult> Update([FromBody] EditClienteRequest editClienteRequest)
        {
            if (string.IsNullOrEmpty(editClienteRequest.Codigo))
            {
                //return ApiResult.Fail("Debe enviar el código del cliente");
                throw new BusinessException("Debe enviar el código del cliente", 409);
            }

            var exists = await _clienteService.GetByCodigo(editClienteRequest.Codigo);

            if (exists is null)
            {
                throw new BusinessException("No existe un cliente registrado con el código proporcionado", 409);
            }

            var exists2 = await _clienteService.GetByNit(editClienteRequest.Nit);

            if (exists2 is not null)
            {
                if (exists.Codigo.Trim() != exists2.Codigo.Trim())
                {
                    throw new BusinessException($"EL Nit {editClienteRequest.Nit} esta asociado a otro código de cliente", 409);
                }
            }

            var cliente = ObjectMapper.Map<EditClienteRequest, EditClienteDTO>(editClienteRequest);
            var id = await _clienteService.Update(cliente);
            return ApiResult.Ok(new { id });
        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<ApiResult> Delete([FromBody] List<string> codigos)
        {
            if (codigos == null || codigos.Count == 0)
                throw new BusinessException("Debe enviar al menos un código de cliente", 409);

            var id = await _clienteService.Delete(codigos);
            return ApiResult.Ok(new { id });
        }
    }
}
