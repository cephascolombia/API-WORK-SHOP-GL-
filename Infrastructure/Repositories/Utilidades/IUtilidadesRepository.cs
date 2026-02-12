using WorkShopGL.Application.DTO;

namespace WorkShopGL.Infrastructure.Repositories.Utilidades
{
    public interface IUtilidadesRepository
    {
        Task<IEnumerable<QueryEmpresaDTO>?> GetAll();
        Task<QueryEmpresaDTO?> GetByNit(string nit);
    }
}
