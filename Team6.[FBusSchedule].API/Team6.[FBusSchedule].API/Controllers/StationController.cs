using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;
using System.Collections.Generic;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly StationsService _stationService;

        public StationController()
        {
            _stationService = new StationsService();
        }

        // GET: api/Station
        [HttpGet]
        public ActionResult<IEnumerable<Station>> GetStations()
        {
            var stations = _stationService.GetStations();
            return Ok(stations);
        }

        // GET: api/Station/5
        [HttpGet("{id}")]
        public ActionResult<Station> GetStation(long id)
        {
            var station = _stationService.GetStationById(id);
            if (station == null)
                return NotFound();
            return Ok(station);
        }

        // POST: api/Station
        [HttpPost]
        public IActionResult Post([FromBody] Station station)
        {
            if (station == null)
                return BadRequest("Invalid data.");

            _stationService.CreateStation(station);
            return CreatedAtAction(nameof(GetStation), new { id = station.StationId }, station);
        }

        // PUT: api/Station/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] _FbusSchedule_.Repository.EntityModel.Station station)
        {
            if (station == null || id != station.StationId)
                return BadRequest("Invalid data.");

            var existingStation = _stationService.GetStationById(id);
            if (existingStation == null)
                return NotFound();

            _stationService.UpdateStation(station);
            return Ok(station);
        }

        // DELETE: api/Station/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var station = _stationService.GetStationById(id);
            if (station == null)
                return NotFound();

            _stationService.DeleteStation(id);
            return Ok(station);
        }

        // GET: api/Station/Count
        [HttpGet("Count")]
        public int Count()
        {
            return _stationService.CountStations();
        }
    }
}
