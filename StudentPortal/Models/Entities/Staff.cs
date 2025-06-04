namespace StudentPortal.Web.Models.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }

        public string Sta_Name { get; set; }
        public string Sta_Email { get; set; }
        public string Sta_PhoneNumber { get; set; }
        public bool Sta_Subscribed { get; set; }

        public string Sta_Entrollment { get; set; }  // Default value for enrollment status
        public string Sta_password { get; set; } // Password field for student login
    }
}