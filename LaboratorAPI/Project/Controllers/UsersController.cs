using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly UserService UserService;

        public UsersController(UserService UserService)
        {
            this.UserService = UserService;
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
        public ActionResult<User> GetUserByUsername(string UserName) 
        {
            var result = UserService.GetUserByUsername(UserName);

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

        [HttpPatch("/delete/{userId}")]
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
