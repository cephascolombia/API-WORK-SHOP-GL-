using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkShopGL.API.Controllers
{
    [Authorize]
    [Route("api/cotizacion")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
    }
}
