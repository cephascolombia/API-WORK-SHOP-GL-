using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkShopGL.API.Models.Request;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Application.DTO;
using WorkShopGL.Application.Services.Auth;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("login")]
        public async Task<ApiResult> Login([FromBody] LoginRequest req)
        {
            var usuario = await _authService.LoginAsync(req.Usuario, req.Password);
            var response = ObjectMapper.Map<LoginResultDTO, LoginResponse>(usuario);
            return ApiResult.Ok(response);
        }

        [HttpPost("create")]
        public async Task<ApiResult> Create([FromBody] CreateUserRequest req)
        {
            var result = await _authService.CreateAsync(req);
            return ApiResult.Ok(result);
        }
    }
}
