using Console.Migration.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TCI.API.Domain.Class.ActivosO.Activos;

namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    // Se crea metodo de la tabla Cliente
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        // se accede a la base de datos de la tabla Cliente
        private readonly SqlServerContext _context;

        public StudentSubjectRepository(SqlServerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que registra la inscripción de un estudiante a una materia
        /// </summary>
        /// <returns></returns>
        public async Task<string> EnrollSubjectAsync(int studentId, int subjectId)
        {
            //  Validar existencia del estudiante
            var student = await _context.Students
                .Include(s => s.StudentSubjects)
                    .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
                return "El estudiante no existe.";

            // Validar existencia de la materia
            var subject = await _context.Subjects
                .Include(s => s.Professor)
                .FirstOrDefaultAsync(s => s.SubjectId == subjectId);

            if (subject == null)
                return  "La materia no existe.";

            //  Máximo 3 materias por estudiante
            if (student.StudentSubjects.Count >= 3)
                return "El estudiante no puede inscribir más de 3 materias.";

            // No repetir materia
            if (student.StudentSubjects.Any(ss => ss.SubjectId == subjectId))
                return "El estudiante ya tiene inscrita esta materia.";

            // No repetir profesor
            var professorIds = student.StudentSubjects
                .Select(ss => ss.Subject.ProfessorId)
                .ToList();

            if (professorIds.Contains(subject.ProfessorId))
                return "El estudiante no puede tener dos materias con el mismo profesor.";

            // Profesor solo puede dictar 2 materias
            var professorSubjectCount = await _context.Subjects
                .CountAsync(s => s.ProfessorId == subject.ProfessorId);

            if (professorSubjectCount > 2)
                return "Este profesor ya tiene asignadas 2 materias.";

            // Registrar inscripción
            var studentSubject = new StudentSubjectDto
            {
                StudentId = studentId,
                SubjectId = subjectId
            };

            _context.StudentSubjects.Add(studentSubject);
            await _context.SaveChangesAsync();
            return "Exito";
        }       
    }
}
