using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class driverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public driverController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }
        // GET: api/Bus
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var _list = await _driverService.Get();
            return Ok(_list);
        }


        // GET: api/Bus/5
        [HttpGet("{DriverID}")]
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


        [HttpPut("{DriverID}")]
        public async Task<IActionResult> Update(int DriverID, DriverVM driverVM)
        {
            var driver = _mapper.Map<DriverVM, Driver>(driverVM);
            driver.DriverId = DriverID;
            await _driverService.UpdateAsync(driver);
            return Ok(driver);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{DriverID}")]
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