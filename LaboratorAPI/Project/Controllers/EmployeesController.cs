﻿using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("/get-all")]
        public ActionResult<List<Employee>> GetAll()
        {
            var result = employeeService.GetAll();

            return Ok(result);
        }

        [HttpPatch("/update")]
        public ActionResult<bool> UpdateEmployeeName([FromBody] EmployeeUpdateDto employeeUpdateModel)
        {
            var result = employeeService.UpdateEmployeeName(employeeUpdateModel);

            if (!result)
            {
                return BadRequest("Employee could not be updated.");
            }

            return Ok(result);
        }

        [HttpGet("/get/{employeeId}")]
        public ActionResult<Employee> GetById(int employeeId)
        {
            var result = employeeService.GetById(employeeId);

            if (result == null)
            {
                return BadRequest("Employee not found");
            }

            return Ok(result);
        }

        [HttpPost("/add")]
        public IActionResult Add([FromBody] EmployeeAddDto payload)
        {
            var result = employeeService.AddEmployee(payload);

            if (result == null)
                return BadRequest("Employee cannot be added");

            return Ok(result);
        }

        [HttpGet("/get-by-userid/{userId}")]
        public ActionResult<Employee> GetByUserId(int userId)
        {
            var result = employeeService.GetByUserID(userId);

            if (result == null)
                return BadRequest("Employee cannot be found");

            return Ok(result);
        }

        [HttpPatch("/delete/{employeeId}")]
        public ActionResult<bool> DeleteEmployee(int employeeId)
        {
            var result = employeeService.DeleteEmployee(employeeId);

            if (!result)
                return BadRequest("Employee cannot be found");

            return Ok(result);
        }
    }

}
