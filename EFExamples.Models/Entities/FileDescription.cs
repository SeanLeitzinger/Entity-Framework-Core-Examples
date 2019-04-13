namespace EFExamples.Models.Entities
{
    public class FileDescription : Entity
    {
        public int DocumentTypeId { get; set; }
        public string ContentType { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}
