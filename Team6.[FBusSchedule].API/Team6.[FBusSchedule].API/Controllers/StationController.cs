using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using System.Linq.Expressions;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stationsController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly IMapper _mapper;
        int PAGE_SIZE = 3;

        public stationsController(IStationService stationService, IMapper mapper)
        {
            _stationService = stationService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null, int page = 1)
        {
            Expression<Func<Station, bool>> filterExpression = null;
            Func<IQueryable<Station>, IOrderedQueryable<Station>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                bool? parsedFilter = TryParseFilter(filter);
                filterExpression = station =>
                     station.StationName.Contains(filter) ||
                     station.Location.Contains(filter) ||
                     (parsedFilter.HasValue && station.StationStatus == parsedFilter.Value);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(station => station.StationId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(station => station.StationId);
                        break;

                    default:
                        orderByFunc = query => query.OrderBy(station => station.StationName);
                        break;
                }
            }

            var stations = await _stationService.Get(filterExpression, orderByFunc);
            var pagestations = PaginatedList<Station>.Create(stations, page, PAGE_SIZE);
            return Ok(pagestations);
        }

        private bool? TryParseFilter(string filter)
        {
            if (bool.TryParse(filter, out bool result))
            {
                return result;
            }
            return null;
        }



        [Authorize]
        [HttpGet("stationid")]
        public async Task<IActionResult> ListByID(int StationID)
        {
            var _listbyid = await _stationService.GetByID(StationID);
            return Ok(_listbyid);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int StationID, StationVM stationVM)
        {
            Station station = new Station();
            station = _mapper.Map<StationVM, Station>(stationVM);
            station.StationId = StationID;
            await _stationService.AddAsync(station);
            return Ok(station);
        }

        [Authorize]
        [HttpPut("stationid")]
        public async Task<IActionResult> Update(int StationID, StationVM stationVM)
        {
            Station station = _mapper.Map<StationVM, Station>(stationVM);
            station.StationId = StationID;
            await _stationService.UpdateAsync(station);
            return Ok(station);
        }


        [Authorize]
        [HttpDelete("stationid")]
        public async Task<IActionResult> Delete(int StationID)
        {
            var station = await _stationService.GetByID(StationID);
            if (station == null)
                return NotFound();

            _stationService.DeleteAsync(StationID);
            return Ok();
        }
    }
}
