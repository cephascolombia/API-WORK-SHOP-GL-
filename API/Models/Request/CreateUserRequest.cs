using System.ComponentModel.DataAnnotations;

namespace WorkShopGL.API.Models.Request
{
    public class CreateUserRequest
    {
        //[Required]
        //public string Usuario { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string? NombreCompleto { get; set; }

        [Required]
        public string? NitEmpresa { get; set; }

        //public string TenantString { get; set; }

        //public string? Rol { get; set; }
    }
}
