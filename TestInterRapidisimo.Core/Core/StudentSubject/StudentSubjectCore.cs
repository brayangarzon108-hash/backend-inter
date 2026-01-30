using TCI.API.Domain.Response.Sistema;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class StudentSubjectCore : IStudentSubjectCore
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly IStudentSubjectRepository _repo;

        public StudentSubjectCore(IStudentSubjectRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        ///  Guardar Materia Alumno
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns> List<ReportesClass> </returns>
        #region  Consultar Materia Alumnos
        public async Task<GeneralResponse> InsertAlumnSubject(StudentSubjectResponse info)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Grupo de Reportes

            var data = await _repo.EnrollSubjectAsync(info.AlumnId, info.SubjectId);

            if (data == ValueString.Exito)
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.Success,
                    Message = data
                };
            }
            else
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.BadRequest,
                    Message = data
                };
            }
        }
        #endregion
    }
}
