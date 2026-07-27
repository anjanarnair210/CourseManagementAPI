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

        // Retrieves all users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);             // 200 OK
        }

        // Retrieves a user by ID
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound();        // 404 Not Found

            return Ok(user);              // 200 OK
        }

        // Creates a new user
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user == null)
                return BadRequest();      // 400 Bad Request

            _userService.AddUser(user);

            return CreatedAtAction(nameof(GetUserById),
                new { id = user.UserId }, user);   // 201 Created
        }

        // Updates an existing user
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (user == null)
                return BadRequest();      // 400 Bad Request

            user.UserId = id;
            _userService.UpdateUser(user);

            return NoContent();           // 204 No Content
        }

        // Deletes a user by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);

            return NoContent();           // 204 No Content
        }
    }
}