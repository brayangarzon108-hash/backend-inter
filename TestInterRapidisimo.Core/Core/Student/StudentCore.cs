using TCI.API.Domain.Response.Sistema;
using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class StudentCore : IStudentCore
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly IStudentRepository _repo;

        public StudentCore(IStudentRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        ///  Guardar Alumno
        /// </summary>
        /// <param name="info"></param>
        /// <returns> List<ReportesClass> </returns>
        public async Task<GeneralResponse> CreateAsync(CreateStudentResponse info)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Crear Alumno
            var data = await _repo.CreateAsync(info);

            if (data == ValueString.Exito)
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.Success,
                    Data = data,
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

        /// <summary>
        /// Actualizar Alumno
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        public async Task<GeneralResponse> UpdateAsync(int studentId, UpdateStudentResponse dto)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Actualizar Alumno
            var data = await _repo.UpdateAsync(studentId, dto);

            if (data == ValueString.Exito)
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.Success,
                    Data = data,
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

        /// <summary>
        /// Actualizar Alumno
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        public async Task<GeneralResponse> DeleteAsync(int studentId)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Eliminar Alumno
            var data = await _repo.DeleteAsync(studentId);

            if (data == ValueString.Exito)
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.Success,
                    Data = data,
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

        /// <summary>
        ///  Consulto Alumnos
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns> List<ReportesClass> </returns>
        #region  Consultar Alumnos
        public async Task<GeneralResponse> GetAllAsync(int studentId)
        {
            GeneralResponse generalResponse = new GeneralResponse();

            // Grupo de Reportes
            var data = await _repo.GetAllAsync(studentId);

            if (data.Count > 0)
            {
                var result = data
                   .Select(s => new StudentListResponse
                   {
                       StudentId = s.StudentId,
                       FullName = s.FullName,
                       Email = s.Email,
                       ProgramName = s.ProgramName
                   })
                    .ToList();
                generalResponse.Data = result;
            }
            else
            {
                return generalResponse = new GeneralResponse
                {
                    Status = (int)Enumerations.enumTypeMessageResponse.NotFound,
                    Message = "No se encontro data con los filtro seleccionados."
                };
            }
            return generalResponse;
        }
        #endregion
    }
}
