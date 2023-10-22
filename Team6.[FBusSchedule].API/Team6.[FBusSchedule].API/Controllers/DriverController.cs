using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public driversController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }
        // GET: api/Bus
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null)
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
            return Ok(drivers);
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
            Driver driver = new Driver();
            driver = _mapper.Map<DriverVM, Driver>(driverVM);
            driver.DriverId = DriverID;
            await _driverService.AddAsync(driver);
            return Ok(driver);
        }


        [HttpPut("driverid")]
        public async Task<IActionResult> Update(int DriverID, DriverVM driverVM)
        {
            var driver = _mapper.Map<DriverVM, Driver>(driverVM);
            driver.DriverId = DriverID;
            await _driverService.UpdateAsync(driver);
            return Ok(driver);
        }

        // DELETE: api/Bus/5
        [HttpDelete("driverid")]
        public async Task<IActionResult> Delete(int DriverID)
        {
            var driver = await _driverService.GetByID(DriverID);
            if (driver == null)
                return NotFound();

            _driverService.DeleteAsync(DriverID);
            return Ok();
        }
    }
}