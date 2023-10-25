using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Drawing.Printing;
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
        int PAGE_SIZE = 3;

        public ticketsstationController(ITicketStationService ticketStationService, IMapper mapper)
        {
            _ticketStationService = ticketStationService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(int page=1)
        {
            var ticketStationList = await _ticketStationService.Get();
            var pageticketStationList = PaginatedList<TicketStation>.Create(ticketStationList, page, PAGE_SIZE);
            return Ok(pageticketStationList);
        }
       
        [Authorize]     
        [HttpGet("ticketstationid")]
        public async Task<IActionResult> GetById(int ticketStationId)
        {
            var ticketStation = await _ticketStationService.GetByID(ticketStationId);
            return Ok(ticketStation);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int ticketStationId, TicketStationVM ticketStationVM)
        {
            TicketStation ticketStation = _mapper.Map<TicketStationVM, TicketStation>(ticketStationVM);
            ticketStation.TicketId = ticketStationId;
            await _ticketStationService.AddAsync(ticketStation);
            return Ok(ticketStation);
        }

        [Authorize]
        [HttpPut("ticketstationid")]
        public async Task<IActionResult> Update(int ticketStationId, [FromBody] TicketStationVM ticketStationVM)
        {
            var ticketStation = _mapper.Map<TicketStationVM, TicketStation>(ticketStationVM);
            ticketStation.TicketId = ticketStationId;
            await _ticketStationService.UpdateAsync(ticketStation);
            return Ok(ticketStation);
        }

        [Authorize]
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
