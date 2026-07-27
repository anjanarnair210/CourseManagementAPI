namespace CourseManagementAPI.models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string UserRole { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsInAdvance { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
    }
}