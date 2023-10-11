using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;
using System.Collections.Generic;
using Team6._FbusSchedule_.Repository.DTO;
using AutoMapper;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        public customerController(IMapper mapper)
        {
            _customerService = new CustomerService();
            _mapper = mapper;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> Get()
        {
            var customers = _customerService.GetCustomers();
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }


        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> Get(long id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }


        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest("Invalid data.");
            }
            var customer = _mapper.Map<Customer>(customerDTO);
            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
           
        }


        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] CustomerDTO customerDto)
        {
            if (customerDto == null || id != customerDto.CustomerId)
                return BadRequest("Invalid data.");

            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null)
                return NotFound();

            // Update properties of existingCustomer from customerDto
            _mapper.Map(customerDto, existingCustomer);

            // Update the customer in the service
            _customerService.UpdateCustomer(existingCustomer);

            // Return the updated CustomerDTO
            var updatedCustomerDto = _mapper.Map<CustomerDTO>(existingCustomer);

            return Ok(updatedCustomerDto);
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
        [HttpGet("count")]
        public int Count()
        {
            return _customerService.CountCustomers();
        }
    }
}
