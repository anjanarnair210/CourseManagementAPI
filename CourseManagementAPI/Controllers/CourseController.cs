using CourseManagementAPI.models;
using CourseManagementAPI.services;
using CourseManagementAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Retrieves all courses from the database.
        /// </summary>
        /// <returns>Returns a list of all available courses.</returns>
        [HttpGet]
        public IActionResult GetCourses()
        {
            try
            {
                var courses = _courseService.GetAllCourses();
                return Ok(courses); // 200 OK
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving courses.");
            }
        }

        /// <summary>
        /// Retrieves a specific course using its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the course.</param>
        /// <returns>Returns the course details if found; otherwise returns 404 Not Found.</returns>
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            try
            {
                var course = _courseService.GetCourseById(id);

                if (course == null)
                    return NotFound(); // 404 Not Found

                return Ok(course); // 200 OK
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the course.");
            }
        }

        /// <summary>
        /// Creates a new course.
        /// </summary>
        /// <param name="courseDto">The course details to be created.</param>
        /// <returns>Returns 201 Created if the course is added successfully.</returns>
        [HttpPost]
        public IActionResult AddCourse(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Course course = new Course
                {
                    Name = courseDto.Name,
                    Description = courseDto.Description,
                    DepartmentId = courseDto.DepartmentId,
                    Duration = courseDto.Duration,
                    StartOfCourse = courseDto.StartOfCourse,
                    EndOfCourse = courseDto.EndOfCourse,
                    Status = courseDto.Status,
                    IsActive = courseDto.IsActive,

                    Fees = courseDto.Fees,
                    PriceOfCourse = courseDto.Fees ?? 0,

                    UserId = 1,
                    CreatedBy = "Admin",
                    CreatedAt = DateTime.Now,
                    ModifiedBy = "Admin",
                    ModifiedAt = DateTime.Now
                };

                _courseService.AddCourse(course);

                return CreatedAtAction(nameof(GetCourseById),
                    new { id = course.CourseId }, course);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the course.");
            }
        }
        /// <summary>
        /// Updates an existing course.
        /// </summary>
        /// <param name="id">The ID of the course to update.</param>
        /// <param name="courseDto">The updated course details.</param>
        /// <returns>Returns 204 No Content if the update is successful.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Course course = new Course
                {
                    CourseId = id,
                    Name = courseDto.Name,
                    Description = courseDto.Description,
                    DepartmentId = courseDto.DepartmentId,
                    Duration = courseDto.Duration,
                    StartOfCourse = courseDto.StartOfCourse,
                    EndOfCourse = courseDto.EndOfCourse,
                    Status = courseDto.Status,
                    IsActive = courseDto.IsActive,

                    Fees = courseDto.Fees,
                    PriceOfCourse = courseDto.Fees ?? 0,

                    UserId = 1,
                    CreatedBy = "Admin",
                    CreatedAt = DateTime.Now,
                    ModifiedBy = "Admin",
                    ModifiedAt = DateTime.Now
                };

                _courseService.UpdateCourse(course);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the course.");
            }
        }
        /// <summary>
        /// Deletes a course by its unique ID.
        /// </summary>
        /// <param name="id">The ID of the course to delete.</param>
        /// <returns>Returns 204 No Content if the course is deleted successfully.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                _courseService.DeleteCourse(id);

                return NoContent(); // 204 No Content
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }
    }
}