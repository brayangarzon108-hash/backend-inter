namespace TestInterRapidisimo.Domain.Model.Response
{
    public class StudentListResponse
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ProgramName { get; set; } = null!;
    }
}
