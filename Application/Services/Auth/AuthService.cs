using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkShopGL.API.Models.Request;
using WorkShopGL.Application.DTO;
using WorkShopGL.Infrastructure.Auth;
using WorkShopGL.Infrastructure.Repositories.Utilidades;
using WorkShopGL.Shared.Exeptions;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.Application.Services.Auth
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUtilidadesRepository _utilidadesRepository;
        private readonly IConfiguration _config;
        private readonly CryptoInt _crypto;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUtilidadesRepository utilidadesRepository, IConfiguration config, CryptoInt cryptoInt )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _utilidadesRepository = utilidadesRepository;
            _config = config;
            _crypto = cryptoInt;
        }

        public async Task<LoginResultDTO> LoginAsync(string user, string password)
        {
            var u = await _userManager.FindByNameAsync(user);

            if (u == null)
                throw new BusinessException("Usuario incorrecto o no existe");

            if (!u.Activo)
                throw new BusinessException("Usuario inactivo");

            if (!await _userManager.CheckPasswordAsync(u, password))
                throw new BusinessException("Credenciales incorrectas");

            return new LoginResultDTO
            {
                Token = GenerateJwt(u),
                UserId = u.Id
            };
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserRequest req)
        {
            var exists = await _userManager.FindByNameAsync(req.Email);
            if (exists != null)
                throw new BusinessException("El usuario ya existe", 409);

            var empresa = await _utilidadesRepository.GetByNit(req.NitEmpresa ?? "");
            if (string.IsNullOrEmpty(empresa.Nit))
                throw new BusinessException("el nit de empresa no existe", 409);

            var user = new ApplicationUser
            {
                UserName = req.Email,
                Email = req.Email,
                TenantString = _crypto.Encrypt(empresa.Id),
                IdEmpresa = empresa?.Id ?? 0,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, req.Password);

            if (!result.Succeeded)
            {
                throw new BusinessException(string.Join(" | ", result.Errors.Select(e => e.Description)));
            }

            //if (!string.IsNullOrWhiteSpace(req.Rol))
            //{
            //    if (!await _roleManager.RoleExistsAsync(req.Rol))
            //        await _roleManager.CreateAsync(new IdentityRole(req.Rol));

            //    await _userManager.AddToRoleAsync(user, req.Rol);
            //}

            return new CreateUserResponseDTO
            {
                UserId = user.Id,
                Usuario = user.UserName!,
                Email = user.Email!
            };
        }

        private string GenerateJwt(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("TenantXUser", user.TenantString)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken
            (
                issuer: "WorkShopGL",
                audience: "WorkShopGL",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
