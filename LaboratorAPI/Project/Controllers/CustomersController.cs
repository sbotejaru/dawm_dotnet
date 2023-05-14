using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomersController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("/get-all")]
        public ActionResult<List<Customer>> GetAll()
        {
            var result = customerService.GetAll();

            return Ok(result);
        }

        [HttpPatch("/update")]
        public ActionResult<bool> UpdateCustomerName([FromBody] CustomerUpdateDto customerUpdateModel)
        {
            var result = customerService.UpdateCustomerName(customerUpdateModel);

            if (!result)
            {
                return BadRequest("Customer could not be updated.");
            }

            return Ok(result);
        }

        [HttpGet("/get/{customerId}")]
        public ActionResult<Customer> GetById(int customerId)
        {
            var result = customerService.GetById(customerId);

            if (result == null)
            {
                return BadRequest("Customer not found");
            }

            return Ok(result);
        }

        [HttpPost("/add")]
        public IActionResult Add([FromBody] CustomerAddDto payload)
        {
            var result = customerService.AddCustomer(payload);

            if (result == null)
                return BadRequest("Customer cannot be added");

            return Ok(result);
        }

        [HttpGet("/get-by-userid/{userId}")]
        public ActionResult<Customer> GetByUserId(int userId)
        {
            var result = customerService.GetByUserID(userId);

            if (result == null)
                return BadRequest("Customer cannot be found");

            return Ok(result);
        }

        [HttpPatch("/delete/{customerId}")]
        public ActionResult<bool> DeleteCustomer(int customerId)
        {
            var result = customerService.DeleteCustomer(customerId);

            if (!result)
                return BadRequest("Customer cannot be found");

            return Ok(result);
        }
    }

}
