using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null)
        {
            Expression<Func<Bus, bool>> filterExpression = null;
            Func<IQueryable<Bus>, IOrderedQueryable<Bus>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                // Filter by searching for the filter string in multiple columns
                filterExpression = bus =>
                    bus.CurrentLocation.Contains(filter.ToUpper()) ||
                    (bus.BusNumber != null && bus.BusNumber.ToString().Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                // Check the orderBy parameter and implement ordering logic
                switch (orderBy.ToLower())
                {
                    case "id":
                        // Order by BusId in ascending order
                        orderByFunc = query => query.OrderBy(bus => bus.BusId);
                        break;
                    case "id_desc":
                        // Order by BusId in descending order
                        orderByFunc = query => query.OrderByDescending(bus => bus.BusId);
                        break;
                    case "seats":
                        // Order by Seats in ascending order
                        orderByFunc = query => query.OrderBy(bus => bus.TotalSeats);
                        break;
                    case "seats_desc":
                        // Order by Seats in descending order
                        orderByFunc = query => query.OrderByDescending(bus => bus.TotalSeats);
                        break;
                    default:
                        // Default to ordering by BusName in ascending order
                        orderByFunc = query => query.OrderBy(bus => bus.BusNumber);
                        break;
                }
            }

            var buses = await _busService.Get(filterExpression, orderByFunc);
            return Ok(buses);
        }


        // GET: api/Bus/5
        [HttpGet("{busid}")]
        public async Task<IActionResult> ListByID(int BusId)
        {
            var _listbyid = await _busService.GetByID(BusId);
            return Ok(_listbyid);
        }

        // POST: api/Bus
        [HttpPost]
        public async Task<IActionResult> Create(int BusID,BusVM busVM)
        {
            Bus bus= new Bus();
            bus = _mapper.Map<BusVM,Bus>(busVM);
            bus.BusId = BusID;
            await _busService.AddAsync(bus);
            return Ok(bus);
        }

        [HttpPut("{busid}")]
        public async Task<IActionResult> Update(int BusId, [FromBody] BusVM busVM)
        {
            var bus = _mapper.Map<BusVM,Bus>(busVM);
            bus.BusId = BusId;
            await _busService.UpdateAsync(bus);
            return Ok(bus);
        }

        [HttpDelete("{busid}")]
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


