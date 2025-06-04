namespace StudentPortal.Web.Models
{
    public class AddCourseViewModel
    {
        public string Title { get; set; }
        public IFormFile? ImageData { get; set; } // Change here
        public string? ImageMimeType { get; set; }
    }
}