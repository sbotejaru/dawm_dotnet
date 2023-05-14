using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RolesController : ControllerBase
    {
        private readonly RoleService RoleService;

        public RolesController(RoleService RoleService)
        {
            this.RoleService = RoleService;
        }

        [HttpGet("/get-all")]
        public ActionResult<List<Role>> GetAll()
        {
            var result = RoleService.GetAll();

            return Ok(result);
        }

        [HttpGet("/get/{RoleId}")]
        public ActionResult<Role> GetById(int RoleId)
        {
            var result = RoleService.GetById((DataLayer.Enums.RoleType)RoleId);

            if (result == null)
            {
                return BadRequest("Role not found");
            }

            return Ok(result);
        }
    }
}
