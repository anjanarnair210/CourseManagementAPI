using CourseManagementAPI.interfaces;
using CourseManagementAPI.models;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        /// <summary>
        /// Retrieves all assignments from the database.
        /// </summary>
        [HttpGet]
        public IActionResult GetAssignments()
        {
            return Ok(_assignmentRepository.GetAllAssignments());
        }

        /// <summary>
        /// Retrieves an assignment by its unique ID.
        /// </summary>
        /// <param name="id">Assignment ID.</param>
        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _assignmentRepository.GetAssignmentById(id);

            if (assignment == null)
                return NotFound();

            return Ok(assignment);
        }

        /// <summary>
        /// Creates a new assignment.
        /// </summary>
        /// <param name="assignment">Assignment details.</param>
        [HttpPost]
        public IActionResult AddAssignment(Assignment assignment)
        {
            if (assignment == null)
            {
                return BadRequest();
            }

            _assignmentRepository.AddAssignment(assignment);

            return Ok("Assignment Added Successfully");
        }

        /// <summary>
        /// Updates an existing assignment.
        /// </summary>
        /// <param name="id">Assignment ID.</param>
        /// <param name="assignment">Updated assignment details.</param>
        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, Assignment assignment)
        {
            assignment.AssignmentId = id;
            _assignmentRepository.UpdateAssignment(assignment);

            return Ok("Assignment Updated Successfully");
        }

        /// <summary>
        /// Deletes an assignment by its unique ID.
        /// </summary>
        /// <param name="id">Assignment ID.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            _assignmentRepository.DeleteAssignment(id);

            return Ok("Assignment Deleted Successfully");
        }
    }
}