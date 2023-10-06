using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;
using System.Collections.Generic;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly BusService _busService;

        public BusController()
        {
            _busService = new BusService();
        }

        // GET: api/Bus
        [HttpGet]
        public ActionResult<IEnumerable<Bus>> Get()
        {
            var buses = _busService.GetBuses();
            return Ok(buses);
        }

        // GET: api/Bus/5
        [HttpGet("{id}")]
        public ActionResult<Bus> Get(long id)
        {
            var bus = _busService.GetBusById(id);
            if (bus == null)
                return NotFound();
            return Ok(bus);
        }

        // POST: api/Bus
        [HttpPost]
        public IActionResult Post([FromBody] Bus bus)
        {
            if (bus == null)
                return BadRequest("Invalid data.");

            _busService.CreateBus(bus);
            return CreatedAtAction(nameof(Get), new { id = bus.BusId }, bus);
        }

        // PUT: api/Bus/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Bus bus)
        {
            if (bus == null || id != bus.BusId)
                return BadRequest("Invalid data.");

            var existingBus = _busService.GetBusById(id);
            if (existingBus == null)
                return NotFound();

            _busService.UpdateBus(bus);
            return Ok(bus);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var bus = _busService.GetBusById(id);
            if (bus == null)
                return NotFound();

            _busService.DeleteBus(id);
            return Ok(bus);
        }

        // GET: api/Bus/Count
        [HttpGet("Count")]
        public int Count()
        {
            return _busService.CountBuses();
        }
    }
}
