
using System.ComponentModel.DataAnnotations.Schema;

namespace TCI.API.Domain.Class.ActivosO.Activos
{
    [Table("StudentSubjects", Schema = "dbo")]
    public class StudentSubjectDto
    {
        public int StudentSubjectId { get; set; }
        public int StudentId { get; set; }
        public StudentDto Student { get; set; } = null!;
        public int SubjectId { get; set; }
        public SubjectDto Subject { get; set; } = null!;
    }
}
