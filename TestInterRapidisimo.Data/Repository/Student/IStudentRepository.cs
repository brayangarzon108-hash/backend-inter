using TestInterRapidisimo.Domain.Model.Response;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IStudentRepository
    {

        Task<string> CreateAsync(CreateStudentResponse dto);
        Task<string> UpdateAsync(int studentId, UpdateStudentResponse dto);
        Task<string> DeleteAsync(int studentId);
        Task<List<StudentListResponse>> GetAllAsync(int studentId);
    }
}
