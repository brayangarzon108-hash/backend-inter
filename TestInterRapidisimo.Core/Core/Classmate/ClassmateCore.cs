using TCI.API.Domain.Response.Sistema;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class ClassmateCore : IClassmateCore
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly IClassmateRepository _repo;

        public ClassmateCore(IClassmateRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        ///  Consulto Grupo Alumnos
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns> List<ReportesClass> </returns>
        #region  Consultar Grupo Alumnos
        public async Task<GeneralResponse> GetClassmatesAsync(int studentId)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // List Devolver
            List<ClassmatesResponse> dataList = new List<ClassmatesResponse>();

            // Grupo de Reportes
            if (studentId > 0)
            {
                var data = await _repo.GetClassmatesAsync(studentId);

                if (data.Count > 0)
                {
                    var result = data
                       .Select(ss => new ClassmatesResponse
                       {
                           SubjectId = ss.SubjectId,
                           SubjectName = ss.SubjectName,
                           Classmates = ss.Classmates
                       })
                        .ToList();
                    generalResponse.Data = dataList;
                }
                else
                {
                    return generalResponse = new GeneralResponse
                    {
                        Status = (int)Enumerations.enumTypeMessageResponse.NotFound,
                        Message = "No se encontro data con los filtro seleccionados."
                    };
                }
            }
            else
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.NotFound,
                    Message = "No se encontro Id de alumno"
                };
            }
            return generalResponse;
        }
        #endregion
    }
}
