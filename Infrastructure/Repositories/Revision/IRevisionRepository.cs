using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShopGL.API.Models.Request;
using WorkShopGL.API.Models.Responses;

namespace WorkShopGL.Infrastructure.Repositories.Revision
{
    public interface IRevisionRepository
    {
        Task<IEnumerable<RevisionResponse>> GetAllAsync(int estado, int id);
        Task<int> InsertAsync(CreateRevisionRequest request);
        Task<int> UpdateAsync(int id, CreateRevisionRequest request);
        Task AnularAsync(int id);
        Task<IEnumerable<RevisionDetalleResponse>> GetChecklistAsync(int id, string idSistema);
        Task<IEnumerable<DiagnosticoResponse>> GetDiagnosticoAsync(int id);
        Task UpsertDiagnosticoAsync(int id, UpsertDiagnosticoRequest request);
        Task<IEnumerable<DiagnosticoResponse>> GetDiagnosticoImpresionAsync(int id);
    }
}
