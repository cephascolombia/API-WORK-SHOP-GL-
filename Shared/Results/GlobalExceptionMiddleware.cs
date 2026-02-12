using System.Net;
using WorkShopGL.Shared.Exeptions;

namespace WorkShopGL.Shared.Results
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(
                    ApiResult.Fail(ex.Message)
                );
            }
            catch (Exception ex)
            {
                // Log completo, pero NO lo expones
                _logger.LogError(ex, "Error no controlado");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync
                (
                    ApiResult.Fail("Ocurrió un error inesperado")
                );
            }
        }
    }
}
