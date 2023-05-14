using Core.Dtos;
using Core.Services;
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

        [HttpGet("/get-all-customers")]
        public ActionResult<List<Customer>> GetAll()
        {
            var result = customerService.GetAll();

            return Ok(result);
        }

        [HttpPatch("/update-customer")]
        public ActionResult<bool> UpdateCustomerName([FromBody] CustomerUpdateDto customerUpdateModel)
        {
            var result = customerService.UpdateCustomerName(customerUpdateModel);

            if (!result)
            {
                return BadRequest("Customer could not be updated.");
            }

            return Ok(result);
        }

        [HttpGet("/get-customer/{customerId}")]
        public ActionResult<Customer> GetById(int customerId)
        {
            var result = customerService.GetById(customerId);

            if (result == null)
            {
                return BadRequest("Customer not found");
            }

            return Ok(result);
        }

        [HttpPost("/add-customer")]
        public IActionResult Add([FromBody] CustomerAddDto payload)
        {
            var result = customerService.AddCustomer(payload);

            if (result == null)
                return BadRequest("Customer cannot be added");

            return Ok(result);
        }

        [HttpGet("/get-customer-by-userid/{userId}")]
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
