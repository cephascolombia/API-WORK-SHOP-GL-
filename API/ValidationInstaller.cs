using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WorkShopGL.Shared.Results;

namespace WorkShopGL.API
{
    public static class ValidationInstaller
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            // Habilita la validación automática para los modelos de tu API
            services.AddFluentValidationAutoValidation();

            // Habilita adaptadores para validación del lado del cliente (por ejemplo en Blazor o Razor Pages)
            services.AddFluentValidationClientsideAdapters();

            // Registra todos los validadores en el assembly donde está esta clase
            services.AddValidatorsFromAssemblyContaining<ValidatorAssemblyMarker>();

            // 2️⃣ Mapear nombres de propiedades al JSON
            FluentValidation.ValidatorOptions.Global.PropertyNameResolver = (type, memberInfo, lambdaExpr) =>
            {
                var jsonProp = memberInfo?.GetCustomAttributes(typeof(System.Text.Json.Serialization.JsonPropertyNameAttribute), true)
                                .Cast<System.Text.Json.Serialization.JsonPropertyNameAttribute>()
                                .FirstOrDefault();
                return jsonProp?.Name ?? memberInfo?.Name;
            };

            // 3️⃣ Manejar errores de validación en ApiResult
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new
                        {
                            Field = string.IsNullOrWhiteSpace(x.Key) ? null : x.Key,
                            Messages = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        })
                        .ToArray();

                    return new BadRequestObjectResult(new ApiResult
                    {
                        Success = false,
                        Message = "Se encontraron errores de validación.",
                        Data = errors
                    });
                };
            });

            return services;
        }
    }

    public class ValidatorAssemblyMarker { }
}
