using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.DTOs
{
    public class CourseDto
    {
        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Course Name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }

        [Range(1, 365,
            ErrorMessage = "Duration must be between 1 and 365 days.")]
        public int Duration { get; set; }

        [Range(100, 100000,
            ErrorMessage = "Fee must be between 100 and 100000.")]
        public decimal Fee { get; set; }

        public string Description { get; set; }

        public DateTime StartOfCourse { get; set; }

        public DateTime EndOfCourse { get; set; }

        public string Status { get; set; }

        public bool IsActive { get; set; }
    }
}