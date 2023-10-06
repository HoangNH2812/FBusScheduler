using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;
using System.Collections.Generic;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly RouteService _routeService;

        public RouteController()
        {
            _routeService = new RouteService();
        }

        // GET: api/Route
        [HttpGet]
        public ActionResult<IEnumerable<_FbusSchedule_.Repository.EntityModel.Route>> Get()
        {
            var routes = _routeService.GetRoutes();
            return Ok(routes);
        }

        // GET: api/Route/5
        [HttpGet("{id}")]
        public ActionResult<_FbusSchedule_.Repository.EntityModel.Route> Get(long id)
        {
            var route = _routeService.GetRouteById(id);
            if (route == null)
                return NotFound();
            return Ok(route);
        }

        // POST: api/Route
        [HttpPost]
        public IActionResult Post([FromBody] _FbusSchedule_.Repository.EntityModel.Route route)
        {
            if (route == null)
                return BadRequest("Invalid data.");

            _routeService.CreateRoute(route);
            return CreatedAtAction(nameof(Get), new { id = route.RouteId }, route);
        }

        // PUT: api/Route/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] _FbusSchedule_.Repository.EntityModel.Route route)
        {
            if (route == null || id != route.RouteId)
                return BadRequest("Invalid data.");

            var existingRoute = _routeService.GetRouteById(id);
            if (existingRoute == null)
                return NotFound();

            _routeService.UpdateRoute(route);
            return Ok(route);
        }

        // DELETE: api/Route/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var route = _routeService.GetRouteById(id);
            if (route == null)
                return NotFound();

            _routeService.DeleteRoute(id);
            return Ok(route);
        }

        // GET: api/Route/Count
        [HttpGet("Count")]
        public int Count()
        {
            return _routeService.CountRoutes();
        }
    }
}
