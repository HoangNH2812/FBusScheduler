using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System;
using System.Drawing;
using System.Linq.Expressions;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public customersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        // GET: api/Bus
        // GET: api/customers

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string ?filter = null, string? orderBy = null, int page = 1)
        {
            Expression<Func<Customer, bool>> filterExpression = null;
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderByFunc = null;
            int PAGE_SIZE = 3;

            if (!string.IsNullOrEmpty(filter))
            {
                bool? parsedFilter = TryParseFilter(filter);
                filterExpression = customer =>
                     customer.CustomerName.Contains(filter) ||
                     (parsedFilter.HasValue && customer.Status == parsedFilter.Value) ||
                     customer.Age.ToString().Equals(filter) ||
                     customer.Email.Contains(filter);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(customer => customer.CustomerId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(customer => customer.CustomerId);
                        break;
                    case "age":
                        orderByFunc = query => query.OrderBy(customer => customer.Age);
                        break;
                    case "age_desc":
                        orderByFunc = query => query.OrderByDescending(customer => customer.Age);
                        break;
                    default:
                        orderByFunc = query => query.OrderBy(customer => customer.CustomerName);
                        break;
                }
            }

            var customers = await _customerService.Get(filterExpression, orderByFunc);
            var pagecustomers = PaginatedList<Customer>.Create(customers, page, PAGE_SIZE);
            return Ok(pagecustomers);
        }
        private bool? TryParseFilter(string filter)
        {
            if (bool.TryParse(filter, out bool result))
            {
                return result;
            }
            return null;
        }

        // GET: api/Bus/5
        [Authorize]
        [HttpGet("customerid")]
        public async Task<IActionResult> ListByID(int CustomerId)
        {
            var _listbyid = await _customerService.GetByID(CustomerId);
            return Ok(_listbyid);
        }

        // POST: api/Bus
        [HttpPost]
        public async Task<IActionResult> Create(int CusID,CustomerVM cusVM)
        {
            Customer cus = new Customer();
            cus = _mapper.Map<CustomerVM, Customer>(cusVM);
            cus.CustomerId = CusID;
            await _customerService.AddAsync(cus);
            return Ok(cus);
        }

        [Authorize]
        [HttpPut("customerid")]
        public async Task<IActionResult> Update(int CustomerId, CustomerVM customerVM)
        {
            var cus = _mapper.Map<CustomerVM, Customer>(customerVM);
            cus.CustomerId = CustomerId;
            await _customerService.UpdateAsync(cus);
            return Ok(cus);
        }

        // DELETE: api/Bus/5
        [Authorize]
        [HttpDelete("customerid")]
        public async Task<IActionResult> Delete(int CustomerId)
        {
            var customer = await _customerService.GetByID(CustomerId);
            if (customer == null)
                return NotFound();
            _customerService.DeleteAsync(CustomerId);
            return Ok();
        }
        // GET: api/customers/byemail
        [Authorize]
        [HttpGet("byemail")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required");
            }

            Expression<Func<Customer, bool>> filterExpression = customer =>
                 customer.Email.ToLower() == email.ToLower();

            var customers = await _customerService.Get(filterExpression, null);
            var customer = customers.SingleOrDefault();

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }

    }
}
