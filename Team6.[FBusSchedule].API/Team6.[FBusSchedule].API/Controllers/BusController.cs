using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;
using System.Collections.Generic;
using AutoMapper;
using Team6._FbusSchedule_.Repository.DTO;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class busController : ControllerBase
    {
        private readonly BusService _busService;
        private readonly IMapper _mapper;

        public busController(IMapper mapper)
        {
            _busService = new BusService();
            _mapper = mapper;
        }

        // GET: api/Bus
        [HttpGet]
        public ActionResult<IEnumerable<BusDTO>> Get()
        {
            var buses = _busService.GetBuses();
            var busDtos = _mapper.Map<IEnumerable<BusDTO>>(buses);
            return Ok(busDtos);
        }

        // GET: api/Bus/5
        [HttpGet("{id}")]
        public ActionResult<BusDTO> Get(long id)
        {
            var bus = _busService.GetBusById(id);
            if (bus == null)
                return NotFound();

            var busDto = _mapper.Map<BusDTO>(bus);
            return Ok(busDto);
        }

        // POST: api/Bus
        [HttpPost]
        public IActionResult Post([FromBody] BusDTO busDto)
        {
            if (busDto == null)
                return BadRequest("Invalid data.");

            // Map from BusDTO to Bus
            var bus = _mapper.Map<Bus>(busDto);

            _busService.CreateBus(bus);
            return CreatedAtAction(nameof(Get), new { id = bus.BusId }, bus);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] BusDTO busDto)
        {
            if (busDto == null || id != busDto.BusId)
                return BadRequest("Invalid data.");

            var existingBus = _busService.GetBusById(id);
            if (existingBus == null)
                return NotFound();

            // Cập nhật các thuộc tính của existingBus từ busDto
            _mapper.Map(busDto, existingBus);

            // Cập nhật Bus trong service
            _busService.UpdateBus(existingBus);

            // Trả về BusDTO sau khi cập nhật
            var updatedBusDto = _mapper.Map<BusDTO>(existingBus);

            return Ok(updatedBusDto);
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
        [HttpGet("count")]
        public int Count()
        {
            return _busService.CountBuses();
        }
    }
}
