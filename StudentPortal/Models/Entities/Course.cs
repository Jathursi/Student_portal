namespace StudentPortal.Web.Models.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
    }
}