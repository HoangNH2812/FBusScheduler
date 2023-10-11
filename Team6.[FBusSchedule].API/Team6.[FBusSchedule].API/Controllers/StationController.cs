using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stationController : ControllerBase
    {
        private readonly StationsService _stationService;
        private readonly IMapper _mapper;

        public stationController(IMapper mapper)
        {
            _stationService = new StationsService();
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StationDTO>> GetStations()
        {
            var stations = _stationService.GetStations();
            var stationDTOs = _mapper.Map<List<StationDTO>>(stations);
            return Ok(stationDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<StationDTO> GetStation(long id)
        {
            var station = _stationService.GetStationById(id);
            if (station == null)
                return NotFound();

            var stationDTO = _mapper.Map<StationDTO>(station);
            return Ok(stationDTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StationDTO stationDTO)
        {
            if (stationDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            var station = _mapper.Map<Station>(stationDTO);
            _stationService.CreateStation(station);
            return CreatedAtAction(nameof(GetStation), new { id = station.StationId }, station);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] StationDTO stationDto)
        {
            if (stationDto == null || id != stationDto.StationId)
                return BadRequest("Invalid data.");

            var existingStation = _stationService.GetStationById(id);
            if (existingStation == null)
                return NotFound();

            _mapper.Map(stationDto, existingStation);
            _stationService.UpdateStation(existingStation);

            var updatedStationDto = _mapper.Map<StationDTO>(existingStation);

            return Ok(updatedStationDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingStation = _stationService.GetStationById(id);

            if (existingStation == null)
            {
                return NotFound();
            }

            _stationService.DeleteStation(id);
            return NoContent();
        }

        [HttpGet("count")]
        public int Count()
        {
            return _stationService.CountStations();
        }
    }
}
