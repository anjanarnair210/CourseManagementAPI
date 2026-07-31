namespace CourseManagementAPI.models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }

        public string ModifiedBy { get; set; } = string.Empty;

        public DateTime ModifiedAt { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}