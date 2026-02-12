using WorkShopGL.Infrastructure.Database;
using WorkShopGL.Shared.Context;
using WorkShopGL.Shared.Exeptions;

namespace WorkShopGL.API.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        private static readonly string[] IgnoredPaths =
        {
            "/api/auth",
            "/swagger"
        };

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantConnectionResolver resolver, TenantContext tenantContext)
        {
            var path = context.Request.Path.Value?.ToLower();

            if (IgnoredPaths.Any(p => path!.StartsWith(p)))
            {
                await _next(context);
                return;
            }

            if (!context.User.Identity?.IsAuthenticated ?? true)
                throw new BusinessException("Token JWT no enviado", 401);

            var tenantKey = context.User.FindFirst("TenantXUser")?.Value;

            if (string.IsNullOrWhiteSpace(tenantKey))
                throw new BusinessException("Tenant no especificado", 400);

            var tenant = await resolver.ResolveAsync(tenantKey);

            if (tenant == null)
                throw new BusinessException("Tenant inválido", 401);

            tenantContext.ConnectionString = tenant;

            await _next(context);
        }

        //public async Task InvokeAsync(HttpContext context, ITenantConnectionResolver resolver, TenantContext tenantContext)
        //{
        //    var path = context.Request.Path.Value?.ToLower();

        //    if (IgnoredPaths.Any(p => path!.StartsWith(p)))
        //    {
        //        await _next(context);
        //        return;
        //    }

        //    var tenantKey = context.Request.Headers["X-Tenant-Key"].FirstOrDefault();

        //    if (string.IsNullOrWhiteSpace(tenantKey))
        //        throw new BusinessException("Tenant no especificado", 400);

        //    var tenant = await resolver.ResolveAsync(tenantKey);

        //    if (tenant == null)
        //        throw new BusinessException("Tenant inválido", 401);

        //    tenantContext.ConnectionString = tenant;

        //    await _next(context);
        //}
    }
}
