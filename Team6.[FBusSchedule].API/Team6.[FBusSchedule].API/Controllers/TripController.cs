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
    public class tripsController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;
        int PAGE_SIZE = 3;

        public tripsController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null,int page=1)
        {
            Expression<Func<Trip, bool>> filterExpression = null;
            Func<IQueryable<Trip>, IOrderedQueryable<Trip>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                bool? parsedFilter = TryParseFilter(filter);
                filterExpression = trip =>
                    trip.TripId.ToString().Contains(filter) ||
                    trip.RouteName.Contains(filter) ||
                    trip.RouteId.ToString().Contains(filter) ||
                    trip.BusId.ToString().Contains(filter) ||
                    trip.DriverId.ToString().Contains(filter) ||
                    (parsedFilter.HasValue && trip.Status == parsedFilter.Value) ||
                    trip.MaxTicket.ToString().Contains(filter);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(trip => trip.TripId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(trip => trip.TripId);
                        break;
                    default:
                        orderByFunc = query => query.OrderBy(trip => trip.TripId);
                        break;
                }
            }

            var trips = await _tripService.Get(filterExpression, orderByFunc);
            var pagetrips = PaginatedList<Trip>.Create(trips, page, PAGE_SIZE);
            return Ok(pagetrips);
        }
        private bool? TryParseFilter(string filter)
        {
            if (bool.TryParse(filter, out bool result))
            {
                return result;
            }
            return null;
        }

        //[Authorize]
        [HttpGet("tripid")]
        public async Task<IActionResult> ListByID(int tripId)
        {
            var trip = await _tripService.GetByID(tripId);
            return Ok(trip);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int tripId, TripVM tripVM)
        {
            Trip trip = _mapper.Map<TripVM, Trip>(tripVM);
            trip.TripId = tripId;
            await _tripService.AddAsync(trip);
            return Ok(trip);
        }

        //[Authorize]
        [HttpPut("tripid")]
        public async Task<IActionResult> Update(int tripId, [FromBody] TripVM tripVM)
        {
            var trip = _mapper.Map<TripVM, Trip>(tripVM);
            trip.TripId = tripId;
            await _tripService.UpdateAsync(trip);
            return Ok(trip);
        }

        //[Authorize]
        [HttpDelete("tripid")]
        public async Task<IActionResult> Delete(int tripId)
        {
            var trip = await _tripService.GetByID(tripId);
            if (trip == null)
                return NotFound();

            await _tripService.DeleteAsync(tripId);
            return Ok();
        }
    }
}
