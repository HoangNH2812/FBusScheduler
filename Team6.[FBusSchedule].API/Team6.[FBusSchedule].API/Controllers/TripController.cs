using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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
    public class tripsController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public tripsController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tripList = await _tripService.Get();
            return Ok(tripList);
        }

        [HttpGet("{tripid}")]
        public async Task<IActionResult> ListByID(int tripId)
        {
            var trip = await _tripService.GetByID(tripId);
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int tripId, TripVM tripVM)
        {
            Trip trip = _mapper.Map<TripVM, Trip>(tripVM);
            trip.TripId = tripId;
            await _tripService.AddAsync(trip);
            return Ok(trip);
        }

        [HttpPut("{tripid}")]
        public async Task<IActionResult> Update(int tripId, [FromBody] TripVM tripVM)
        {
            var trip = _mapper.Map<TripVM, Trip>(tripVM);
            trip.TripId = tripId;
            await _tripService.UpdateAsync(trip);
            return Ok(trip);
        }

        [HttpDelete("{tripid}")]
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
