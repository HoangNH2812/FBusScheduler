using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ticketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public ticketsController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null)
        {
            Expression<Func<Ticket, bool>> filterExpression = null;
            Func<IQueryable<Ticket>, IOrderedQueryable<Ticket>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                filterExpression = ticket =>
                     ticket.TicketId.ToString().Contains(filter) ||
                     ticket.CustomerName.Contains(filter) ||
                     ticket.CustomerId.ToString().Contains(filter) ||
                     ticket.Comment.Contains(filter) ||
                     ticket.Status.ToString().Contains(filter) ||
                     ticket.TripId.ToString().Contains(filter);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(ticket => ticket.TicketId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(ticket => ticket.TicketId);
                        break;
                    default:
                        orderByFunc = query => query.OrderBy(ticket => ticket.TicketId);
                        break;
                }
            }

            var tickets = await _ticketService.Get(filterExpression, orderByFunc);
            return Ok(tickets);
        }

        [HttpGet("ticketid")]
        public async Task<IActionResult> ListByID(int ticketId)
        {
            var ticket = await _ticketService.GetByID(ticketId);
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int ticketId, TicketVM ticketVM)
        {
            Ticket ticket = _mapper.Map<TicketVM, Ticket>(ticketVM);
            ticket.TicketId = ticketId;
            await _ticketService.AddAsync(ticket);
            return Ok(ticket);
        }

        [HttpPut("ticketid")]
        public async Task<IActionResult> Update(int ticketId, [FromBody] TicketVM ticketVM)
        {
            var ticket = _mapper.Map<TicketVM, Ticket>(ticketVM);
            ticket.TicketId = ticketId;
            await _ticketService.UpdateAsync(ticket);
            return Ok(ticket);
        }

        [HttpDelete("ticketid")]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var ticket = await _ticketService.GetByID(ticketId);
            if (ticket == null)
                return NotFound();

            await _ticketService.DeleteAsync(ticketId);
            return Ok();
        }
        [HttpGet("tripid")]
        public async Task<IActionResult> CountByTripId(int tripId)
        {
            int ticketCount = await _ticketService.CountByTripId(tripId);

            return Ok(ticketCount);
        }

    }
}
