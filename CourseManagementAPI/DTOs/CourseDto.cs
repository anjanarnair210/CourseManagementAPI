using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.DTOs
{
    public class CourseDto
    {
        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Course Name must be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        public string Duration { get; set; } = string.Empty;

        [Range(100, 100000, ErrorMessage = "Fee must be between 100 and 100000.")]
        public decimal? Fees { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime StartOfCourse { get; set; }

        public DateTime EndOfCourse { get; set; }

        public string Status { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}