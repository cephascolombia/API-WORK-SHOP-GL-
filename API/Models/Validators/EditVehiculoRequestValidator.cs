using FluentValidation;
using WorkShopGL.API.Models.Request;

namespace WorkShopGL.API.Models.Validators
{
    public class EditVehiculoRequestValidator : AbstractValidator<EditVehiculoRequest>
    {
        public EditVehiculoRequestValidator() 
        {
            // Requeridos
            RuleFor(x => x.Placa)
                .NotEmpty()
                .WithMessage("La placa es obligatoria");

            RuleFor(x => x.Modelo)
                .NotEmpty()
                .WithMessage("El modelo es obligatorio")
                .MaximumLength(20)
                .WithMessage("El código del cliente no puede tener más de 20 caracteres");

            RuleFor(x => x.Codigo_marca)
                .NotEmpty()
                .WithMessage("El código de la marca es obligatorio")
                .MaximumLength(4)
                .WithMessage("El código del cliente no puede tener más de 4 caracteres");

            RuleFor(x => x.Codigo_cliente)
                .MaximumLength(20)
                .WithMessage("El código del cliente no puede tener más de 20 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Codigo_cliente));

            RuleFor(x => x.Codigo_color)
                .MaximumLength(4)
                .WithMessage("El código del color no puede tener más de 4 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Codigo_color));

            RuleFor(x => x.Codigo_carroceria)
                .MaximumLength(4)
                .WithMessage("El código de la carrocería no puede tener más de 4 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Codigo_carroceria));

            RuleFor(x => x.Codigo_clase)
                .MaximumLength(4)
                .WithMessage("El código de la clase no puede tener más de 4 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Codigo_clase));

            RuleFor(x => x.Cilindraje)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El cilindraje debe ser mayor o igual que 0")
                .When(x => x.Cilindraje != 0);
        }
    }
}
