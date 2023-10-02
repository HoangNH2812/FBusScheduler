using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerService customerService = new CustomerService();
        // GET: api/<CustomerController>
        [HttpGet]
        public List<Customer> Get()
        {
            List<Customer> result = new List<Customer>();
            var cuList = customerService.GetCustomers();
            cuList.ForEach(row => result.Add(new Customer()
            {
                CustomerId = row.CustomerId,
                CustomerName = row.CustomerName,
                Age = row.Age,
                Email = row.Email,
            }));
            return result;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public long Get(long id)
        {
            var count= customerService.Count(id);
            return count;
        }

       /* // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
