using TCI.API.Domain.Response.Sistema;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IClassmateCore
    {

        /// <summary>
        ///  Consulto Grupo Alumnos
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns> List<ReportesClass> </returns>
        Task<GeneralResponse> GetClassmatesAsync(int studentId);
    }
}
