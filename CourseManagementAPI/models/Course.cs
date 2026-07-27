namespace CourseManagementAPI.models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Duration { get; set; } = string.Empty;
        public DateTime StartOfCourse { get; set; }
        public DateTime EndOfCourse { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal PriceOfCourse { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentId { get; set; }
        public decimal? Fees { get; set; }
    }
}