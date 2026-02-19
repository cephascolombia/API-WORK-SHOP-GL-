using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.Application.Services.Prosistema;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers;

[Authorize]
[Route("api/prosistema")]
[ApiController]
public class ProsistemaController(IProsistemaService prosistemaService) : ControllerBase
{
    [HttpGet("sistemas")]
    [Authorize]
    public async Task<ApiResult> GetSistemas()
    {
        var sistemas = await prosistemaService.GetSistemasAsync();
        return ApiResult.Ok(sistemas);
    }

    [HttpGet("componentes/{codSistema}")]
    [Authorize]
    public async Task<ApiResult> GetComponentes(string codSistema)
    {
        var componentes = await prosistemaService.GetComponentesBySistemaAsync(codSistema);
        return ApiResult.Ok(componentes);
    }

    [HttpGet("buscar")]
    [Authorize]
    public async Task<ApiResult> Buscar([FromQuery] string q)
    {
        var resultados = await prosistemaService.BuscarComponentesAsync(q);
        return ApiResult.Ok(resultados);
    }
}