using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Drawing.Printing;
using System.Linq.Expressions;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FBusSchedule_.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class busesController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly IMapper _mapper;

        public busesController(IBusService busService, IMapper mapper)
        {
            _busService = busService;
            _mapper = mapper;
        }
        // GET: api/Bus
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null, int page = 1)
        {
            Expression<Func<Bus, bool>> filterExpression = null;
            Func<IQueryable<Bus>, IOrderedQueryable<Bus>> orderByFunc = null;
            int PAGE_SIZE = 3;

            if (!string.IsNullOrEmpty(filter))
            {

                bool? parsedFilter = TryParseFilter(filter);
                // Filter by searching for the filter string in multiple columns
                filterExpression = bus =>
                    bus.CurrentLocation.Contains(filter.ToUpper()) ||
                    (parsedFilter.HasValue && bus.Status == parsedFilter.Value) ||
                    (bus.BusNumber != null && bus.BusNumber.ToString().Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {

                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(bus => bus.BusId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(bus => bus.BusId);
                        break;
                    case "seats":
                        orderByFunc = query => query.OrderBy(bus => bus.TotalSeats);
                        break;
                    case "seats_desc":
                        orderByFunc = query => query.OrderByDescending(bus => bus.TotalSeats);
                        break;
                    default:
                        orderByFunc = query => query.OrderBy(bus => bus.BusNumber);
                        break;
                }
            }

            var buses = await _busService.Get(filterExpression, orderByFunc);
            var pagebuses = PaginatedList<Bus>.Create(buses, page, PAGE_SIZE);
            return Ok(pagebuses);
        }

        private bool? TryParseFilter(string filter)
        {
            if (bool.TryParse(filter, out bool result))
            {
                return result;
            }
            return null;
        }

        // GET: api/Bus/5
        [Authorize]
        [HttpGet("busid")]
        public async Task<IActionResult> ListByID(int BusId)
        {
            var _listbyid = await _busService.GetByID(BusId);
            return Ok(_listbyid);
        }

        // POST: api/Bus
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int BusID,BusVM busVM)
        {
            Bus bus= new Bus();
            bus = _mapper.Map<BusVM,Bus>(busVM);
            bus.BusId = BusID;
            await _busService.AddAsync(bus);
            return Ok(bus);
        }

        [Authorize]
        [HttpPut("busid")]
        public async Task<IActionResult> Update(int BusId, [FromBody] BusVM busVM)
        {
            var bus = _mapper.Map<BusVM,Bus>(busVM);
            bus.BusId = BusId;
            await _busService.UpdateAsync(bus);
            return Ok(bus);
        }

        [Authorize]
        [HttpDelete("busid")]
        public async Task<IActionResult> Delete(int BusId)
        {
            var bus = await _busService.GetByID(BusId);
            if (bus == null)
                return NotFound();

            _busService.DeleteAsync(BusId);
            return Ok();
        }
    }
}


