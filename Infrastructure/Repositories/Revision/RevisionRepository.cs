using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WorkShopGL.API.Models.Request;
using WorkShopGL.API.Models.Responses;
using WorkShopGL.Infrastructure.Database;

namespace WorkShopGL.Infrastructure.Repositories.Revision
{
    public class RevisionRepository : IRevisionRepository
    {
        private readonly SqlExecutor _sqlExecutor;

        public RevisionRepository(SqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public async Task<IEnumerable<RevisionResponse>> GetAllAsync(int estado, int id)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("proc_ingreso_vehiculo", rd =>
            {
                return new RevisionResponse
                {
                    Codigo = rd["codigo"] != DBNull.Value ? rd["codigo"].ToString() : string.Empty,
                    NroOrden = rd["nroOrden"] != DBNull.Value ? rd["nroOrden"].ToString() : string.Empty,
                    NroCotiza = rd["nrocotiza"] != DBNull.Value ? rd["nrocotiza"].ToString() : string.Empty,
                    Fecha = rd["fecha"] != DBNull.Value ? rd["fecha"].ToString() : string.Empty,
                    Observaciones = rd["observaciones"] != DBNull.Value ? rd["observaciones"].ToString() : string.Empty,
                    FechaIngreso = rd["fechaIngreso"] != DBNull.Value ? rd["fechaIngreso"].ToString() : string.Empty,
                    HoraIngreso = rd["horaIngreso"] != DBNull.Value ? rd["horaIngreso"].ToString() : string.Empty,
                    FechaSalida = rd["fechaSalida"] != DBNull.Value ? rd["fechaSalida"].ToString() : string.Empty,
                    HoraSalida = rd["horaSalida"] != DBNull.Value ? rd["horaSalida"].ToString() : string.Empty,
                    Placa = rd["placa"] != DBNull.Value ? rd["placa"].ToString() : string.Empty,
                    Cliente = rd["cliente"] != DBNull.Value ? rd["cliente"].ToString() : string.Empty,
                    NombreCliente = rd["nombreCliente"] != DBNull.Value ? rd["nombreCliente"].ToString() : string.Empty,
                    TipoTrabajo = rd["tipoTrabajo"] != DBNull.Value ? rd["tipoTrabajo"].ToString() : string.Empty,
                    NomTipoTrabajo = rd["nomTipoTrabajo"] != DBNull.Value ? rd["nomTipoTrabajo"].ToString() : string.Empty,
                    NivelCombustible = rd["nivelCombustible"] != DBNull.Value ? rd["nivelCombustible"].ToString() : string.Empty,
                    Kilometraje = rd["kilometraje"] != DBNull.Value ? Convert.ToDecimal(rd["kilometraje"]) : 0,
                    Tecnico = rd["tecnico"] != DBNull.Value ? rd["tecnico"].ToString() : string.Empty,
                    NombreTecnico = rd["nombreTecnico"] != DBNull.Value ? rd["nombreTecnico"].ToString() : string.Empty,
                    FechaServer = rd["fecha_server"] != DBNull.Value ? rd["fecha_server"].ToString() : string.Empty,
                    Estacion = rd["estacion"] != DBNull.Value ? rd["estacion"].ToString() : string.Empty,
                    Usuario = rd["usuario"] != DBNull.Value ? rd["usuario"].ToString() : string.Empty,
                    NombreUsuario = rd["nombreUsuario"] != DBNull.Value ? rd["nombreUsuario"].ToString() : string.Empty,
                    Estado = rd["estado"] != DBNull.Value ? Convert.ToInt32(rd["estado"]) : 0,
                    Id = rd["id"] != DBNull.Value ? Convert.ToInt32(rd["id"]) : 0,
                    IdSistema = rd["idSistema"] != DBNull.Value ? rd["idSistema"].ToString() : string.Empty,
                    Solucion = rd["solucion"] != DBNull.Value ? rd["solucion"].ToString() : string.Empty
                };
            }, p =>
            {
                p.AddWithValue("@operacion", "S");
                p.AddWithValue("@estado", estado);
                p.AddWithValue("@ID", id);
            });
        }

        public async Task<int> InsertAsync(CreateRevisionRequest request)
        {
            var xmlString = SerializeToXml(request.Detalles);

            var idResult = await _sqlExecutor.ExecuteScalarAsync<decimal>("proc_ingreso_vehiculo", p =>
            {
                p.AddWithValue("@operacion", "I");
                p.AddWithValue("@nroOrden", request.NroOrden ?? "");
                p.AddWithValue("@fecha", request.Fecha ?? "");
                p.AddWithValue("@observaciones", request.Observaciones ?? "");
                p.AddWithValue("@fechaIngreso", request.FechaIngreso ?? "");
                p.AddWithValue("@horaIngreso", request.HoraIngreso ?? "");
                p.AddWithValue("@fechaSalida", request.FechaSalida ?? "");
                p.AddWithValue("@horaSalida", request.HoraSalida ?? "");
                p.AddWithValue("@placa", request.Placa ?? "");
                p.AddWithValue("@cliente", request.Cliente ?? "");
                p.AddWithValue("@tipoTrabajo", request.TipoTrabajo ?? "");
                p.AddWithValue("@nivelCombustible", request.NivelCombustible ?? "");
                p.AddWithValue("@kilometraje", request.Kilometraje);
                p.AddWithValue("@tecnico", request.Tecnico ?? "");
                p.AddWithValue("@usuario", request.Usuario ?? "");
                p.AddWithValue("@estado", request.Estado);
                p.AddWithValue("@IdSistema", request.IdSistema ?? "");
                p.AddWithValue("@ListaItemIngresoVeh", xmlString);
            });

            return Convert.ToInt32(idResult);
        }

        public async Task<int> UpdateAsync(int id, CreateRevisionRequest request)
        {
            var xmlString = SerializeToXml(request.Detalles);

            await _sqlExecutor.ExecuteNonQueryAsync("proc_ingreso_vehiculo", p =>
            {
                p.AddWithValue("@operacion", "U");
                p.AddWithValue("@ID", id);
                p.AddWithValue("@fecha", request.Fecha ?? "");
                p.AddWithValue("@observaciones", request.Observaciones ?? "");
                p.AddWithValue("@fechaIngreso", request.FechaIngreso ?? "");
                p.AddWithValue("@horaIngreso", request.HoraIngreso ?? "");
                p.AddWithValue("@fechaSalida", request.FechaSalida ?? "");
                p.AddWithValue("@horaSalida", request.HoraSalida ?? "");
                p.AddWithValue("@placa", request.Placa ?? "");
                p.AddWithValue("@cliente", request.Cliente ?? "");
                p.AddWithValue("@tipoTrabajo", request.TipoTrabajo ?? "");
                p.AddWithValue("@nivelCombustible", request.NivelCombustible ?? "");
                p.AddWithValue("@kilometraje", request.Kilometraje);
                p.AddWithValue("@tecnico", request.Tecnico ?? "");
                p.AddWithValue("@usuario", request.Usuario ?? "");
                p.AddWithValue("@IdSistema", request.IdSistema ?? "");
                p.AddWithValue("@ListaItemIngresoVeh", xmlString);
            });

            return id;
        }

        public async Task AnularAsync(int id)
        {
            await _sqlExecutor.ExecuteNonQueryAsync("proc_ingreso_vehiculo", p =>
            {
                p.AddWithValue("@operacion", "A");
                p.AddWithValue("@ID", id);
            });
        }

        public async Task<IEnumerable<RevisionDetalleResponse>> GetChecklistAsync(int id, string idSistema)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("proc_ingreso_vehiculo", rd =>
            {
                return new RevisionDetalleResponse
                {
                    Codigo = rd["codigo"] != DBNull.Value ? rd["codigo"].ToString() : string.Empty,
                    NroOrden = rd["nroOrden"] != DBNull.Value ? rd["nroOrden"].ToString() : string.Empty,
                    NroCotiza = rd["nrocotiza"] != DBNull.Value ? rd["nrocotiza"].ToString() : string.Empty,
                    Fecha = rd["fecha"] != DBNull.Value ? rd["fecha"].ToString() : string.Empty,
                    Observaciones = rd["observaciones"] != DBNull.Value ? rd["observaciones"].ToString() : string.Empty,
                    FechaIngreso = rd["fechaIngreso"] != DBNull.Value ? rd["fechaIngreso"].ToString() : string.Empty,
                    HoraIngreso = rd["horaIngreso"] != DBNull.Value ? rd["horaIngreso"].ToString() : string.Empty,
                    FechaSalida = rd["fechaSalida"] != DBNull.Value ? rd["fechaSalida"].ToString() : string.Empty,
                    HoraSalida = rd["horaSalida"] != DBNull.Value ? rd["horaSalida"].ToString() : string.Empty,
                    Placa = rd["placa"] != DBNull.Value ? rd["placa"].ToString() : string.Empty,
                    Cliente = rd["cliente"] != DBNull.Value ? rd["cliente"].ToString() : string.Empty,
                    NombreCliente = rd["nombreCliente"] != DBNull.Value ? rd["nombreCliente"].ToString() : string.Empty,
                    TipoTrabajo = rd["tipoTrabajo"] != DBNull.Value ? rd["tipoTrabajo"].ToString() : string.Empty,
                    NomTipoTrabajo = rd["nomTipoTrabajo"] != DBNull.Value ? rd["nomTipoTrabajo"].ToString() : string.Empty,
                    NivelCombustible = rd["nivelCombustible"] != DBNull.Value ? rd["nivelCombustible"].ToString() : string.Empty,
                    Kilometraje = rd["kilometraje"] != DBNull.Value ? Convert.ToDecimal(rd["kilometraje"]) : 0,
                    Tecnico = rd["tecnico"] != DBNull.Value ? rd["tecnico"].ToString() : string.Empty,
                    NombreTecnico = rd["nombreTecnico"] != DBNull.Value ? rd["nombreTecnico"].ToString() : string.Empty,
                    Item = rd["item"] != DBNull.Value ? rd["item"].ToString() : string.Empty,
                    Falla = rd["falla"] != DBNull.Value && Convert.ToBoolean(rd["falla"]),
                    ObservacionDetalle = rd["observacion"] != DBNull.Value ? rd["observacion"].ToString() : string.Empty,
                    NomSubSistema = rd["nomsubsistema"] != DBNull.Value ? rd["nomsubsistema"].ToString() : string.Empty
                };
            }, p =>
            {
                p.AddWithValue("@operacion", "IMP");
                p.AddWithValue("@ID", id);
                p.AddWithValue("@IdSistema", idSistema);
            });
        }

        public async Task<IEnumerable<DiagnosticoResponse>> GetDiagnosticoAsync(int id)
        {
            return await _sqlExecutor.ExecuteReaderListAsync("proc_ingreso_vehiculo", rd =>
            {
                return new DiagnosticoResponse
                {
                    Id = rd["id"] != DBNull.Value ? Convert.ToInt32(rd["id"]) : 0,
                    DiagPreliminar = rd["diagPreliminar"] != DBNull.Value ? rd["diagPreliminar"].ToString() : string.Empty,
                    DiagTecnico = rd["diagTecnico"] != DBNull.Value ? rd["diagTecnico"].ToString() : string.Empty,
                    Solucion = rd["solucion"] != DBNull.Value ? rd["solucion"].ToString() : string.Empty
                };
            }, p =>
            {
                p.AddWithValue("@operacion", "S_DIAG");
                p.AddWithValue("@ID", id);
            });
        }

        public async Task UpsertDiagnosticoAsync(int id, UpsertDiagnosticoRequest request)
        {
            await _sqlExecutor.ExecuteNonQueryAsync("proc_ingreso_vehiculo", p =>
            {
                p.AddWithValue("@operacion", "I_DIAG");
                p.AddWithValue("@ID", id);
                p.AddWithValue("@diagPreliminar", request.DiagPreliminar ?? "");
                p.AddWithValue("@diagTecnico", request.DiagTecnico ?? "");
                p.AddWithValue("@solucion", request.Solucion ?? "");
                p.AddWithValue("@usuario", request.Usuario ?? "");
            });
        }

        public async Task<IEnumerable<DiagnosticoResponse>> GetDiagnosticoImpresionAsync(int id)
        {
             return await _sqlExecutor.ExecuteReaderListAsync("proc_ingreso_vehiculo", rd =>
            {
                return new DiagnosticoResponse
                {
                    IdIngreso = rd["idIngreso"] != DBNull.Value ? rd["idIngreso"].ToString() : string.Empty,
                    Placa = rd["placa"] != DBNull.Value ? rd["placa"].ToString() : string.Empty,
                    Cliente = rd["clinom"] != DBNull.Value ? rd["clinom"].ToString() : string.Empty,
                    Tecnico = rd["tecnom"] != DBNull.Value ? rd["tecnom"].ToString() : string.Empty,
                    DiagPreliminar = rd["diagPreliminar"] != DBNull.Value ? rd["diagPreliminar"].ToString() : string.Empty,
                    DiagTecnico = rd["diagtecnico"] != DBNull.Value ? rd["diagtecnico"].ToString() : string.Empty,
                    Solucion = rd["solucion"] != DBNull.Value ? rd["solucion"].ToString() : string.Empty,
                    NombreUsuario = rd["nombreUsuario"] != DBNull.Value ? rd["nombreUsuario"].ToString() : string.Empty,
                    FechaIngreso = rd["fechaingreso"] != DBNull.Value ? rd["fechaingreso"].ToString() : string.Empty,
                    HoraIngreso = rd["horaIngreso"] != DBNull.Value ? rd["horaIngreso"].ToString() : string.Empty
                };
            }, p =>
            {
                p.AddWithValue("@operacion", "IMP_DIAG");
                p.AddWithValue("@ID", id);
            });
        }

        private string SerializeToXml(List<ItemTallerRequest> detalles)
        {
            if (detalles == null || !detalles.Any())
                return string.Empty;

            var sb = new StringBuilder();
            sb.Append("<ArrayOfClsItemTaller>");
            foreach (var d in detalles)
            {
                sb.Append("<ClsItemTaller>");
                sb.Append($"<IdItemTaller>{d.IdItemTaller}</IdItemTaller>");
                sb.Append($"<falla>{(d.Falla ? "1" : "0")}</falla>");
                sb.Append($"<observacion><![CDATA[{d.Observacion ?? ""}]]></observacion>");
                sb.Append($"<posicion>{d.Posicion ?? ""}</posicion>");
                sb.Append("</ClsItemTaller>");
            }
            sb.Append("</ArrayOfClsItemTaller>");
            return sb.ToString();
        }
    }
}
