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
    public class driverController : ControllerBase
    {
        private readonly DriverService _driverService;
        private readonly IMapper _mapper;

        public driverController(IMapper mapper)
        {
            _driverService = new DriverService();
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DriverDTO>> Get()
        {
            var drivers = _driverService.GetDrivers();
            var driverDTOs = _mapper.Map<List<DriverDTO>>(drivers);
            return Ok(driverDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<DriverDTO> Get(long id)
        {
            var driver = _driverService.GetDriverById(id);
            if (driver == null)
                return NotFound();

            var driverDTO = _mapper.Map<DriverDTO>(driver);
            return Ok(driverDTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DriverDTO driverDTO)
        {
            if (driverDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            var driver = _mapper.Map<Driver>(driverDTO);
            _driverService.CreateDriver(driver);
            return CreatedAtAction(nameof(Get), new { id = driver.DriverId }, driver);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] DriverDTO driverDto)
        {
            if (driverDto == null || id != driverDto.DriverId)
                return BadRequest("Invalid data.");

            var existingDriver = _driverService.GetDriverById(id);
            if (existingDriver == null)
                return NotFound();

            _mapper.Map(driverDto, existingDriver);
            _driverService.UpdateDriver(existingDriver);

            var updatedDriverDto = _mapper.Map<DriverDTO>(existingDriver);

            return Ok(updatedDriverDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingDriver = _driverService.GetDriverById(id);

            if (existingDriver == null)
            {
                return NotFound();
            }

            _driverService.DeleteDriver(id);
            return NoContent();
        }

        [HttpGet("count")]
        public int Count()
        {
            return _driverService.CountDrivers();
        }
    }
}
