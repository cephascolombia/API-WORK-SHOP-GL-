using Microsoft.AspNetCore.Identity;

namespace WorkShopGL.Infrastructure.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public bool Activo { get; set; }
        public int IdEmpresa { get; set; }
        public string TenantString { get; set; }
    }
}
