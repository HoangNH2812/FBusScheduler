using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ticketsstationController : ControllerBase
    {
        private readonly ITicketStationService _ticketStationService;
        private readonly IMapper _mapper;

        public ticketsstationController(ITicketStationService ticketStationService, IMapper mapper)
        {
            _ticketStationService = ticketStationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var ticketStationList = await _ticketStationService.Get();
            return Ok(ticketStationList);
        }

        [HttpGet("ticketstationid")]
        public async Task<IActionResult> GetById(int ticketStationId)
        {
            var ticketStation = await _ticketStationService.GetByID(ticketStationId);
            return Ok(ticketStation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int ticketStationId, TicketStationVM ticketStationVM)
        {
            TicketStation ticketStation = _mapper.Map<TicketStationVM, TicketStation>(ticketStationVM);
            ticketStation.TicketId = ticketStationId;
            await _ticketStationService.AddAsync(ticketStation);
            return Ok(ticketStation);
        }

        [HttpPut("ticketstationid")]
        public async Task<IActionResult> Update(int ticketStationId, [FromBody] TicketStationVM ticketStationVM)
        {
            var ticketStation = _mapper.Map<TicketStationVM, TicketStation>(ticketStationVM);
            ticketStation.TicketId = ticketStationId;
            await _ticketStationService.UpdateAsync(ticketStation);
            return Ok(ticketStation);
        }

        [HttpDelete("ticketstationid")]
        public async Task<IActionResult> Delete(int ticketStationId)
        {
            var ticketStation = await _ticketStationService.GetByID(ticketStationId);
            if (ticketStation == null)
                return NotFound();

            await _ticketStationService.DeleteAsync(ticketStationId);
            return Ok();
        }
    }
}
