using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Drawing.Printing;
using System.Linq.Expressions;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class driversController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;
        int PAGE_SIZE = 3;

        public driversController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }
        // GET: api/Bus
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null, int page = 1)
        {
            Expression<Func<Driver, bool>> filterExpression = null;
            Func<IQueryable<Driver>, IOrderedQueryable<Driver>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                bool? parsedFilter = TryParseFilter(filter);
                filterExpression = driver =>
                    driver.DriverName.Contains(filter) ||
                    driver.Email.Contains(filter) ||
                    (parsedFilter.HasValue && driver.Status == parsedFilter.Value) ||
                    (driver.DriverPhone != null && driver.DriverPhone.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(driver => driver.DriverId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(driver => driver.DriverId);
                        break;
                    case "license":
                        orderByFunc = query => query.OrderBy(driver => driver.License);
                        break;
                    case "license_desc":
                        orderByFunc = query => query.OrderByDescending(driver => driver.License);
                        break;
                    default:
                        orderByFunc = query => query.OrderBy(driver => driver.DriverName);
                        break;
                }
            }

            var drivers = await _driverService.Get(filterExpression, orderByFunc);
            var pagedrivers = PaginatedList<Driver>.Create(drivers, page, PAGE_SIZE);
            return Ok(pagedrivers);
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
        [HttpGet("driverid")]
        public async Task<IActionResult> ListByID(int DriverID)
        {
            var _listbyid = await _driverService.GetByID(DriverID);
            return Ok(_listbyid);
        }

        // POST: api/Bus
        [HttpPost]
        public async Task<IActionResult> Create(int DriverID, DriverVM driverVM)
        {
            if (!await _driverService.IsEmailUnique(driverVM.Email))
            {
                return BadRequest("Email already exists");
            }

            Driver driver = new Driver();
            driver = _mapper.Map<DriverVM, Driver>(driverVM);
            driver.DriverId = DriverID;
            await _driverService.AddAsync(driver);
            return Ok(driver);
        }

        [Authorize]
        [HttpPut("driverid")]
        public async Task<IActionResult> Update(int DriverID, DriverVM driverVM)
        {
            if (!await _driverService.IsEmailUnique(driverVM.Email))
            {
                return BadRequest("Email already exists");
            }

            var driver = _mapper.Map<DriverVM, Driver>(driverVM);
            driver.DriverId = DriverID;
            await _driverService.UpdateAsync(driver);
            return Ok(driver);
        }

        // DELETE: api/Bus/5
        [Authorize]
        [HttpDelete("driverid")]
        public async Task<IActionResult> Delete(int DriverID)
        {
            var driver = await _driverService.GetByID(DriverID);
            if (driver == null)
                return NotFound();

            _driverService.DeleteAsync(DriverID);
            return Ok();
        }
        // GET: api/driver/byemail
        [Authorize]
        [HttpGet("byemail")]
        public async Task<IActionResult> GetDriverByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required");
            }

            Expression<Func<Driver, bool>> filterExpression = driver =>
                driver.Email.ToLower() == email.ToLower();

            var drivers = await _driverService.Get(filterExpression, null);
            var driver = drivers.SingleOrDefault();

            if (driver == null)
            {
                return NotFound("Customer not found");
            }
            var driverVM = _mapper.Map<Driver, DriverVM>(driver);
            return Ok(driverVM);
        }
    }
}