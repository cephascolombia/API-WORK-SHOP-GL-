namespace WorkShopGL.Infrastructure.Database
{
    public interface ITenantConnectionResolver
    {
        Task<string> ResolveAsync(string tenantKey);
    }
}
