using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stationController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly IMapper _mapper;

        public stationController(IStationService stationService, IMapper mapper)
        {
            _stationService = stationService;
            _mapper = mapper;
        }
        // GET: api/Bus
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var _list = await _stationService.Get();
            return Ok(_list);
        }


        // GET: api/Bus/5
        [HttpGet("{StationID}")]
        public async Task<IActionResult> ListByID(int StationID)
        {
            var _listbyid = await _stationService.GetByID(StationID);
            return Ok(_listbyid);
        }

        // POST: api/Bus
        [HttpPost]
        public async Task<IActionResult> Create(int StationID, StationVM stationVM)
        {
            Station station = new Station();
            station = _mapper.Map<StationVM, Station>(stationVM);
            station.StationId = StationID;
            await _stationService.AddAsync(station);
            return Ok(station);
        }


        [HttpPut("{StationID}")]
        public async Task<IActionResult> Update(int StationID, StationVM stationVM)
        {
            Station station = _mapper.Map<StationVM, Station>(stationVM);
            station.StationId = StationID;
            await _stationService.UpdateAsync(station);
            return Ok(station);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{StationID}")]
        public async Task<IActionResult> Delete(int StationID)
        {
            var station = await _stationService.GetByID(StationID);
            if (station == null)
                return NotFound();

            _stationService.DeleteAsync(StationID);
            return Ok();
        }
    }
}
