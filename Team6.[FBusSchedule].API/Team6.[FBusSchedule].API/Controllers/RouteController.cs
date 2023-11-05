using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;
using Route = Team6._FbusSchedule_.Repository.EntityModel.Route;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class routesController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;
        int PAGE_SIZE = 3;

        public routesController(IRouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }
        // GET: api/Bus
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null, int page = 1)
        {
            Expression<Func<Route, bool>> filterExpression = null;
            Func<IQueryable<Route>, IOrderedQueryable<Route>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {
                bool? parsedFilter = TryParseFilter(filter);
                filterExpression = route =>
                    route.Destination.Contains(filter) ||
                    route.StartingLocation.Contains(filter) ||
                    route.Distance.Contains(filter) ||
                    route.RouteName.Contains(filter) ||
                    (parsedFilter.HasValue && route.Status == parsedFilter.Value);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(route => route.RouteId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(route => route.RouteId);
                        break;          
                    default:
                        orderByFunc = query => query.OrderBy(route => route.RouteId); 
                        break;
                }
            }

            var routes = await _routeService.Get(filterExpression, orderByFunc);
            var pageroutes = PaginatedList<Route>.Create(routes, page, PAGE_SIZE);
            return Ok(pageroutes);
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
        [HttpGet("routeid")]
        public async Task<IActionResult> ListByID(int RouteID)
        {
            var _listbyid = await _routeService.GetByID(RouteID);
            return Ok(_listbyid);
        }

        // POST: api/Bus
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int RouteID, RouteVM routeVM)
        {
            Route route = new Route();
            route = _mapper.Map<RouteVM, Route>(routeVM);
            route.RouteId = RouteID;
            await _routeService.AddAsync(route);
            return Ok(route);
        }

        [Authorize]
        [HttpPut("routeid")]
        public async Task<IActionResult> Update(int RouteID, RouteVM routeVM)
        {
            var route = _mapper.Map<RouteVM, Route>(routeVM);
            route.RouteId = RouteID;
            await _routeService.UpdateAsync(route);
            return Ok(route);
        }

        // DELETE: api/Bus/5
        [Authorize]
        [HttpDelete("routeid")]
        public async Task<IActionResult> Delete(int RouteID)
        {
            var route = await _routeService.GetByID(RouteID);
            if (route == null)
                return NotFound();

            _routeService.DeleteAsync(RouteID);
            return Ok();
        }
        [Authorize]
        [HttpGet("getroutebyname")]
        public async Task<IActionResult> GetRouteByName(string routeName)
        {
            string normalizedRouteName = routeName.ToLower();

            Expression<Func<Route, bool>> filterExpression = route => route.RouteName.ToLower() == normalizedRouteName;

            var routes = await _routeService.Get(filterExpression, null);
            return Ok(routes);
        }


    }
}
