using WorkShopGL.API.Models.Request;
using FluentValidation;

namespace WorkShopGL.API.Models.Validators
{
    public class CreateClienteRequestValidator : AbstractValidator<CreateClienteRequest>
    {
        public CreateClienteRequestValidator()
        {
            RuleFor(x => x.TipoDocumento)
                .NotEmpty().WithMessage("El tipo de documento es obligatorio")
                .MaximumLength(2).WithMessage("El tipo de documento debe tener máximo 2 caracteres")
                .Must(v => new[] { "CC", "NI", "CE", "TI","PA","PT","PE" }.Contains(v))
                .WithMessage("Tipo de documento inválido");

            RuleFor(x => x.TipoPersona)
                .Must(v => v == 1 || v == 2)
                .WithMessage("Tipo de persona inválido (1 = Natural, 2 = Jurídica)");

            RuleFor(x => x)
                .Must(ValidarTipoPersona)
                .WithMessage("Si el documento es NIT, el tipo de persona debe ser Jurídica");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria")
                .MaximumLength(200).WithMessage("La dirección no puede superar los 200 caracteres");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio")
                .MaximumLength(50).WithMessage("El teléfono no puede superar los 50 caracteres");

            RuleFor(x => x.Celular)
                .MaximumLength(50).WithMessage("El celular no puede superar los 50 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Celular));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .MaximumLength(200).WithMessage("El email no puede superar los 200 caracteres")
                .EmailAddress().WithMessage("El email no es válido");

            RuleFor(x => x.CodigoCiudad)
                .NotEmpty().WithMessage("El código de ciudad es obligatorio")
                .MaximumLength(5).WithMessage("El código de ciudad no puede superar los 5 caracteres");

            RuleFor(x => x.CodigoPais)
                .NotEmpty().WithMessage("El código de país es obligatorio")
                .MaximumLength(4).WithMessage("El código de país no puede superar los 4 caracteres");
        }

        private bool ValidarTipoPersona(CreateClienteRequest x)
        {
            if (x.TipoDocumento == "NI" && x.TipoPersona != 2)
                return false;

            return true;
        }
    }
}
