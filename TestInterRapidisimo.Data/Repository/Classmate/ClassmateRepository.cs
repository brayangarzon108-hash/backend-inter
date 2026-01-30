using Console.Migration.Context;
using Microsoft.EntityFrameworkCore;
using TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato;
using TestInterRapidisimo.Domain.Model.Response;

namespace StudentRegistration.API.Services;

public class ClassmateRepository : IClassmateRepository
{
    private readonly SqlServerContext _context;

    public ClassmateRepository(SqlServerContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método que consulta los estudiante que comparten materias con un estudiante.
    /// </summary>
    /// <returns></returns>
    public async Task<List<ClassmatesResponse>> GetClassmatesAsync(int studentId)
    {
        // Validar estudiante
        var exists = await _context.Students.AnyAsync(s => s.StudentId == studentId);
        if (!exists)
            throw new Exception("El estudiante no existe.");

        var result = await _context.StudentSubjects
            .Where(ss => ss.StudentId == studentId)
            .Select(ss => new ClassmatesResponse
            {
                SubjectId = ss.Subject.SubjectId,
                SubjectName = ss.Subject.Name,
                Classmates = _context.StudentSubjects
                    .Where(x => x.SubjectId == ss.SubjectId && x.StudentId != studentId)
                    .Select(x => x.Student.FullName)
                    .Distinct()
                    .ToList()
            })
            .ToListAsync();

        return result;
    }
}
