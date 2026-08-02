using CourseManagementAPI.DTOs;
using CourseManagementAPI.models;
using CourseManagementAPI.services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Searches users by user name.
        /// </summary>
        /// <param name="request">Search request.</param>
        [HttpGet("search")]
        public IActionResult SearchUsers([FromQuery] UserSearchRequest request)
        {
            var users = _userService.SearchUsers(request);
            return Ok(users);
        }

        /// <summary>
        /// Retrieves a specific user using its unique ID.
        /// </summary>
        /// <param name="id">User ID.</param>
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">User details.</param>
        
        [HttpPost]
        public IActionResult AddUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                DepartmentId = userDto.DepartmentId,
                UserRole = userDto.UserRole,
                Password = userDto.Password,
                Age = userDto.Age,
                Status = userDto.Status,
                IsInAdvance = userDto.IsInAdvance,
                IsActive = userDto.IsActive,

                RegisteredDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            };

            _userService.AddUser(user);

            return CreatedAtAction(nameof(GetUserById),
                new { id = user.UserId }, user);
        }
        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="userDto">Updated user details.</param>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User
            {
                UserId = id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                DepartmentId = userDto.DepartmentId,
                UserRole = userDto.UserRole,
                Password = userDto.Password,
                Age = userDto.Age,
                Status = userDto.Status,
                IsInAdvance = userDto.IsInAdvance,
                IsActive = userDto.IsActive,

                RegisteredDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            };

            _userService.UpdateUser(user);

            return NoContent();
        }
        /// <summary>
        /// Deletes a user by its unique ID.
        /// </summary>
        /// <param name="id">User ID.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);

            return NoContent();
        }
    }
}