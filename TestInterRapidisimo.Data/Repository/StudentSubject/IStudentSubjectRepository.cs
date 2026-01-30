namespace TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato
{
    public interface IStudentSubjectRepository
    {

        /// <summary>
        /// Método que registra la inscripción de un estudiante a una materia
        /// </summary>
        /// <returns></returns>
       Task<string> EnrollSubjectAsync(int studentId, int subjectId);
    }
}
