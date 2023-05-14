using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService;

        public AdminController(AdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("/get-all")]
        public ActionResult<List<Admin>> GetAll()
        {
            var result = adminService.GetAll();

            return Ok(result);
        }

        [HttpPatch("/update")]
        public ActionResult<bool> UpdateAdminName([FromBody] AdminUpdateDto adminUpdateModel)
        {
            var result = adminService.UpdateAdminName(adminUpdateModel);

            if (!result)
            {
                return BadRequest("Admin could not be updated.");
            }

            return Ok(result);
        }

        [HttpGet("/get/{adminId}")]
        public ActionResult<Admin> GetById(int adminId)
        {
            var result = adminService.GetById(adminId);

            if (result == null)
            {
                return BadRequest("Admin not found");
            }

            return Ok(result);
        }
    }
}
