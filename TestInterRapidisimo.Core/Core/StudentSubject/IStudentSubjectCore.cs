using TCI.API.Domain.Response.Sistema;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IStudentSubjectCore
    {

        /// <summary>
        ///  Guardar Materia Alumno
        /// </summary>
        /// <param name="info"></param>
        /// <returns> List<ReportesClass> </returns>
        Task<GeneralResponse> InsertAlumnSubject(StudentSubjectResponse info);
    }
}
