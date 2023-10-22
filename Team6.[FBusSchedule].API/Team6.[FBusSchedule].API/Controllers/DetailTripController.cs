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
    public class detailsTripController : ControllerBase
    {
        private readonly IDetailTripService _detailTripService;
        private readonly IMapper _mapper;

        public detailsTripController(IDetailTripService detailTripService, IMapper mapper)
        {
            _detailTripService = detailTripService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null)
        {
            Expression<Func<DetailTrip, bool>> filterExpression = null;
            Func<IQueryable<DetailTrip>, IOrderedQueryable<DetailTrip>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                string[] filterParts = filter.Split('|');
                if (filterParts.Length == 2 && DateTime.TryParse(filterParts[0], out DateTime filterDate))
                {
                    filterExpression = detailTrip =>
                        detailTrip.TripId.ToString().Contains(filterParts[1]) ||
                        detailTrip.StationId.ToString().Contains(filterParts[1]) ||
                        detailTrip.ArrivalTime.HasValue && detailTrip.ArrivalTime.Value.Date == filterDate.Date;
                }
                else
                {
                    filterExpression = detailTrip =>
                        detailTrip.TripId.ToString().Contains(filter) ||
                        detailTrip.StationId.ToString().Contains(filter);
                }
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "tripid":
                        orderByFunc = query => query.OrderBy(detailTrip => detailTrip.TripId);
                        break;
                    case "tripid_desc":
                        orderByFunc = query => query.OrderByDescending(detailTrip => detailTrip.TripId);
                        break;
                    case "stationid":
                        orderByFunc = query => query.OrderBy(detailTrip => detailTrip.StationId);
                        break;
                    case "stationid_desc":
                        orderByFunc = query => query.OrderByDescending(detailTrip => detailTrip.StationId);
                        break;
                    default:
                        orderByFunc = query => query.OrderBy(detailTrip => detailTrip.TripId);
                        break;
                }
            }

            var detailTripList = await _detailTripService.Get(filterExpression, orderByFunc);
            return Ok(detailTripList);
        }

        [HttpGet("detailtripid")]
        public async Task<IActionResult> GetById(int id)
        {
            var detailTrip = await _detailTripService.GetByID(id);
            return Ok(detailTrip);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetailTripVM detailTripVM)
        {
            var detailTrip = _mapper.Map<DetailTripVM, DetailTrip>(detailTripVM);
            await _detailTripService.AddAsync(detailTrip);
            return Ok(detailTrip);
        }

        [HttpPut("detailtripid")]
        public async Task<IActionResult> Update(int id, [FromBody] DetailTripVM detailTripVM)
        {
            var existingDetailTrip = await _detailTripService.GetByID(id);
            if (existingDetailTrip == null)
                return NotFound();

            var updatedDetailTrip = _mapper.Map(detailTripVM, existingDetailTrip);
            await _detailTripService.UpdateAsync(updatedDetailTrip);

            return Ok(updatedDetailTrip);
        }

        [HttpDelete("detailtripid")]
        public async Task<IActionResult> Delete(int id)
        {
            var detailTrip = await _detailTripService.GetByID(id);
            if (detailTrip == null)
                return NotFound();

            await _detailTripService.DeleteAsync(id);
            return Ok();
        }
    }
}
