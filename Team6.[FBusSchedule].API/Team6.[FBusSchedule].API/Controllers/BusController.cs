using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> List()
        {
            var _list = await _busService.Get();
            return Ok(_list);
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


