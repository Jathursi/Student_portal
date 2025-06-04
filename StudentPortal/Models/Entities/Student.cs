namespace StudentPortal.Web.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Subscribed { get; set; }

        public string Entrollment { get; set; }  // Default value for enrollment status
        public string password { get; set; } // Password field for student login
    }
}