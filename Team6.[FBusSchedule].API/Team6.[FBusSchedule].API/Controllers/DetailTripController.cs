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
    public class detailsTripController : ControllerBase
    {
        private readonly IDetailTripService _detailTripService;
        private readonly IMapper _mapper;
        int PAGE_SIZE = 3;

        public detailsTripController(IDetailTripService detailTripService, IMapper mapper)
        {
            _detailTripService = detailTripService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(int page=1)
        {
            var detailTripList = await _detailTripService.Get();
            var pagedetailTripList = PaginatedList<DetailTrip>.Create(detailTripList, page, PAGE_SIZE);
            return Ok(pagedetailTripList);
        }

        [Authorize]
        [HttpGet("tripidAndstationid")]
        public async Task<IActionResult> GetById(int tripid, int stationid)
        {
            var detailTrip = await _detailTripService.GetByTripAndStationId(tripid, stationid);
            if (detailTrip == null)
                return NotFound();

            return Ok(detailTrip);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetailTripVM detailTripVM)
        {
            var detailTrip = _mapper.Map<DetailTripVM, DetailTrip>(detailTripVM);
            await _detailTripService.AddAsync(detailTrip);
            return Ok(detailTrip);
        }

        [Authorize]
        [HttpPut("tripidAndstationid")]
        public async Task<IActionResult> Update(int tripid, int stationid, [FromBody] DetailTripVM detailTripVM)
        {
            var existingDetailTrip = await _detailTripService.GetByTripAndStationId(tripid, stationid);
            if (existingDetailTrip == null)
                return NotFound();

            var updatedDetailTrip = _mapper.Map(detailTripVM, existingDetailTrip);
            await _detailTripService.UpdateAsync(updatedDetailTrip);

            return Ok(updatedDetailTrip);
        }

        [Authorize]
        [HttpDelete("tripidAndstationid")]
        public async Task<IActionResult> Delete(int tripid, int stationid)
        {
            var detailTrip = await _detailTripService.GetByTripAndStationId(tripid, stationid);
            if (detailTrip == null)
                return NotFound();

            await _detailTripService.DeleteAsync(detailTrip);
            return Ok();
        }
    }
}
