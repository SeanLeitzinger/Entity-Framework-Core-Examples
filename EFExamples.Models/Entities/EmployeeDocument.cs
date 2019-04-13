namespace EFExamples.Models.Entities
{
    public class EmployeeDocument
    {
        public int FileDescriptionId { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public FileDescription FileDescription { get; set; }
    }
}
