using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;
using System.Collections.Generic;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(long id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Invalid data.");

            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Customer customer)
        {
            if (customer == null || id != customer.CustomerId)
                return BadRequest("Invalid data.");

            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null)
                return NotFound();

            _customerService.UpdateCustomer(customer);
            return Ok(customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            _customerService.DeleteCustomer(id);
            return Ok(customer);
        }

        // GET: api/Customer/Count
        [HttpGet("Count")]
        public int Count()
        {
            return _customerService.CountCustomers();
        }
    }
}
