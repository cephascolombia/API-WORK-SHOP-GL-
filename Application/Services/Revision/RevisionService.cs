using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopGL.API.Models.Request;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Infrastructure.Repositories.Revision;

namespace WorkShopGL.Application.Services.Revision
{
    public class RevisionService : IRevisionService
    {
        private readonly IRevisionRepository _repository;

        public RevisionService(IRevisionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RevisionResponse>> GetAllAsync(int estado, int id)
            => await _repository.GetAllAsync(estado, id);

        public async Task<int> InsertAsync(CreateRevisionRequest request)
            => await _repository.InsertAsync(request);

        public async Task<int> UpdateAsync(int id, CreateRevisionRequest request)
            => await _repository.UpdateAsync(id, request);

        public async Task AnularAsync(int id)
            => await _repository.AnularAsync(id);

        public async Task<ChecklistResponse> GetChecklistAsync(int id, string idSistema)
        {
            var rawData = await _repository.GetChecklistAsync(id, idSistema);
            if (rawData == null || !rawData.Any())
                return new ChecklistResponse();

            var firstRow = rawData.First();
            var cabecera = new RevisionResponse
            {
                Codigo = firstRow.Codigo,
                NroOrden = firstRow.NroOrden,
                NroCotiza = firstRow.NroCotiza,
                Fecha = firstRow.Fecha,
                Observaciones = firstRow.Observaciones,
                FechaIngreso = firstRow.FechaIngreso,
                HoraIngreso = firstRow.HoraIngreso,
                FechaSalida = firstRow.FechaSalida,
                HoraSalida = firstRow.HoraSalida,
                Placa = firstRow.Placa,
                Cliente = firstRow.Cliente,
                NombreCliente = firstRow.NombreCliente,
                TipoTrabajo = firstRow.TipoTrabajo,
                NomTipoTrabajo = firstRow.NomTipoTrabajo,
                NivelCombustible = firstRow.NivelCombustible,
                Kilometraje = firstRow.Kilometraje,
                Tecnico = firstRow.Tecnico,
                NombreTecnico = firstRow.NombreTecnico,
                FechaServer = firstRow.FechaServer,
                Estacion = firstRow.Estacion,
                Usuario = firstRow.Usuario,
                NombreUsuario = firstRow.NombreUsuario,
                Estado = firstRow.Estado,
                Id = firstRow.Id,
                IdSistema = firstRow.IdSistema,
                Solucion = firstRow.Solucion
            };

            var subsistemas = rawData
                .Where(x => !string.IsNullOrEmpty(x.NomSubSistema))
                .GroupBy(x => x.NomSubSistema)
                .Select(g => new ChecklistSubsistemaResponse
                {
                    NombreSubsistema = g.Key,
                    Componentes = g.Select(c => new ChecklistComponenteResponse
                    {
                        Componente = c.Item,
                        Falla = c.Falla,
                        ObservacionDetalle = c.ObservacionDetalle
                    }).ToList()
                }).ToList();

            return new ChecklistResponse
            {
                Cabecera = cabecera,
                Subsistemas = subsistemas
            };
        }

        public async Task<IEnumerable<DiagnosticoResponse>> GetDiagnosticoAsync(int id)
            => await _repository.GetDiagnosticoAsync(id);

        public async Task UpsertDiagnosticoAsync(int id, UpsertDiagnosticoRequest request)
            => await _repository.UpsertDiagnosticoAsync(id, request);

        public async Task<IEnumerable<DiagnosticoResponse>> GetDiagnosticoImpresionAsync(int id)
            => await _repository.GetDiagnosticoImpresionAsync(id);
    }
}
