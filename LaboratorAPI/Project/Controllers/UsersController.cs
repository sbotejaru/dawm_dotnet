using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserService UserService;

        public UsersController(UserService UserService)
        {
            this.UserService = UserService;
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto payload)
        {
            UserService.RegisterUser(payload);
            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload)
        {
            var jwtToken = UserService.Validate(payload);

            return Ok(new { token = jwtToken });
        }

        [HttpGet("test-auth")]
        public IActionResult TestLogin()
        {
            ClaimsPrincipal user = User;

            var result = "";

            foreach (var claim in user.Claims)
            {
                result += claim.Type + " : " + claim.Value + "\n";
            }

            return Ok(result);
        }

        [HttpGet("customers-only")]
        [Authorize(Roles = "1")]
        public ActionResult<string> HelloCustomers()
        {
            return Ok("Hello customers!");
        }

        [HttpGet("employees-only")]
        [Authorize(Roles = "2")]
        public ActionResult<string> HelloEmployees()
        {
            return Ok("Hello employees!");
        }

        [HttpGet("admins-only")]
        [Authorize(Roles = "3")]
        public ActionResult<string> HelloAdmins()
        {
            return Ok("Hello admins!");
        }

        [HttpGet("/get-all-users")]
        public ActionResult<List<User>> GetAll()
        {
            var result = UserService.GetAll();

            return Ok(result);
        }

        [HttpGet("/get-user/{UserId}")]
        public ActionResult<User> GetById(int UserId)
        {
            var result = UserService.GetById(UserId);

            if (result == null)
            {
                return BadRequest("User not found");
            }

            return Ok(result);
        }

        [HttpGet("/get-by-username/{username}")]
        public ActionResult<User> GetUserByUsername(string username) 
        {
            var result = UserService.GetUserByUsername(username);

            if (result == null)
            {
                return BadRequest("User with such username was not found");
            }

            return Ok(result);

        }

        [HttpGet("/get-by-role/{role}")]
        public ActionResult<List<User>> GetUsersByRole(RoleType role)
        {
            var result = UserService.GetUsersByRole(role);

            return Ok(result);

        }

        [HttpGet("/get-by-username-and-password/{username}/{password}")]
        public ActionResult<User> GetUserByUsernameAndPassword(string username, string password) 
        {
            var result = UserService.GetUserByUsernameAndPassword(username, password);

            if (result == null)
            {
                return BadRequest("User with such credentials was not found");
            }

            return Ok(result);

        }

        [HttpPatch("/update-password")]
        public ActionResult<bool> UpdateUserPassword ([FromBody] UserUpdatePasswordDTO payload)
        {
            var result = UserService.UpdateUserPassword(payload);

            if (!result)
            {
                return BadRequest("User's password could not be updated.");
            }

            return Ok(result);

        }

        [HttpPatch("/update-role")]
        public ActionResult<bool> UpdateUserRole([FromBody] UserUpdateRoleDto payload)
        {
            var result = UserService.UpdateUserRole(payload);

            if (!result)
            {
                return BadRequest("User's role could not be updated.");
            }

            return Ok(result);

        }

        [HttpPatch("/delete-user/{userId}")]
        public ActionResult<bool> DeleteUser(int userId)
        {
            var result = UserService.DeleteUser(userId);

            if (!result)
            {
                return BadRequest("User could not be deleted.");
            }

            return Ok(result);
        }

        [HttpPost("/add-user")]
        public IActionResult Add([FromBody] UserAddDto payload)
        {
            var result = UserService.AddUser(payload);

            if (result == null)
            {
                return BadRequest("User cannot be added");
            }

            return Ok(result);

        }

    }
}
