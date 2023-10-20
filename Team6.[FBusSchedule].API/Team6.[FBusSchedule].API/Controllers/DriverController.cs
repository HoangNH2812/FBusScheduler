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
        public async Task<IActionResult> List(string filter = null, string orderBy = null)
        {
            Expression<Func<Driver, bool>> filterExpression = null;
            Func<IQueryable<Driver>, IOrderedQueryable<Driver>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                // Filter by searching for the filter string in multiple columns
                filterExpression = driver =>
                    driver.DriverName.Contains(filter) ||
                    driver.Email.Contains(filter) ||
                    (driver.DriverPhone != null && driver.DriverPhone.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                // Check the orderBy parameter and implement ordering logic
                switch (orderBy.ToLower())
                {
                    case "id":
                        // Order by DriverId in ascending order
                        orderByFunc = query => query.OrderBy(driver => driver.DriverId);
                        break;
                    case "id_desc":
                        // Order by DriverId in descending order
                        orderByFunc = query => query.OrderByDescending(driver => driver.DriverId);
                        break;
                    case "license":
                        // Order by License in ascending order
                        orderByFunc = query => query.OrderBy(driver => driver.License);
                        break;
                    case "license_desc":
                        // Order by License in descending order
                        orderByFunc = query => query.OrderByDescending(driver => driver.License);
                        break;
                    default:
                        // Default to ordering by DriverName in ascending order
                        orderByFunc = query => query.OrderBy(driver => driver.DriverName);
                        break;
                }
            }

            var drivers = await _driverService.Get(filterExpression, orderByFunc);
            return Ok(drivers);
        }


        // GET: api/Bus/5
        [HttpGet("{driverid}")]
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


        [HttpPut("{driverid}")]
        public async Task<IActionResult> Update(int DriverID, DriverVM driverVM)
        {
            var driver = _mapper.Map<DriverVM, Driver>(driverVM);
            driver.DriverId = DriverID;
            await _driverService.UpdateAsync(driver);
            return Ok(driver);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{driverid}")]
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