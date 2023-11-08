using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
        int PAGE_SIZE = 3;

        public ticketsController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null, int page = 1)
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
            var pagetickets = PaginatedList<Ticket>.Create(tickets, page, PAGE_SIZE);
            return Ok(pagetickets);
        }

        [Authorize]
        [HttpGet("ticketid")]
        public async Task<IActionResult> ListByID(int ticketId)
        {
            var ticket = await _ticketService.GetByID(ticketId);
            return Ok(ticket);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int ticketId, TicketVM ticketVM)
        {
            Ticket ticket = _mapper.Map<TicketVM, Ticket>(ticketVM);
            ticket.TicketId = ticketId;
            await _ticketService.AddAsync(ticket);
            return Ok(ticket);
        }

        [Authorize]
        [HttpPut("ticketid")]
        public async Task<IActionResult> Update(int ticketId, [FromBody] TicketVM ticketVM)
        {
            var ticket = _mapper.Map<TicketVM, Ticket>(ticketVM);
            ticket.TicketId = ticketId;
            await _ticketService.UpdateAsync(ticket);
            return Ok(ticket);
        }

        [Authorize]
        [HttpDelete("ticketid")]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var ticket = await _ticketService.GetByID(ticketId);
            if (ticket == null)
                return NotFound();

            await _ticketService.DeleteAsync(ticketId);
            return Ok();
        }
        [Authorize]
        [HttpGet("tripid")]
        public async Task<IActionResult> ListByTripId(int tripId)
        {
            var ticketCount = await _ticketService.ListByTripId(tripId);

            return Ok(ticketCount);
        }
        [Authorize]
        [HttpGet("getticketbycustomerid")]
        public async Task<IActionResult> GetTicketByCustomerId(int customerId)
        {
            Expression<Func<Ticket, bool>> filterExpression = ticket => ticket.CustomerId == customerId;

            var tickets = await _ticketService.Get(filterExpression, null);
            return Ok(tickets);
        }
        [Authorize]
        [HttpGet("count/tripid")]
        public async Task<IActionResult> CountByTripId(int tripId)
        {
            var ticketCount = await _ticketService.CountByTripId(tripId);

            return Ok(ticketCount);
        }
    }
}
