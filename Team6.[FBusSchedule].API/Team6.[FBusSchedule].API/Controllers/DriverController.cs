using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriverController()
        {
            _driverService = new DriverService();
        }

        // GET: api/Driver
        [HttpGet]
        public List<Driver> Get()
        {
            return _driverService.GetDrivers();
        }

        // GET: api/Driver/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> Get(long id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // POST: api/Driver
        [HttpPost]
        public IActionResult Post([FromBody] Driver driver)
        {
            _driverService.CreateDriver(driver);
            return CreatedAtAction(nameof(Get), new { id = driver.DriverId }, driver);
        }

        // PUT: api/Driver/{id}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Driver driver)
        {
            if (id != driver.DriverId)
            {
                return BadRequest();
            }

            _driverService.UpdateDriver(driver);
            return NoContent();
        }

        // DELETE: api/Driver/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingDriver = _driverService.GetDriverByIdAsync(id).Result;

            if (existingDriver == null)
            {
                return NotFound();
            }

            _driverService.DeleteDriver(id);
            return NoContent();
        }

        // GET: api/Driver/Count
        [HttpGet("Count")]
        public int Count()
        {
            return _driverService.CountDrivers();
        }
    }
}
