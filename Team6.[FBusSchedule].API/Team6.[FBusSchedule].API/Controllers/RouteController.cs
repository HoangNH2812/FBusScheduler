using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Service.Service;
using Route = Team6._FbusSchedule_.Repository.EntityModel.Route;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class routeController : ControllerBase
    {
        private readonly RouteService _routeService;
        private readonly IMapper _mapper;

        public routeController(IMapper mapper)
        {
            _routeService = new RouteService();
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RouteDTO>> Get()
        {
            var routes = _routeService.GetRoutes();
            var routeDTOs = _mapper.Map<List<RouteDTO>>(routes);
            return Ok(routeDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<RouteDTO> Get(long id)
        {
            var route = _routeService.GetRouteById(id);
            if (route == null)
                return NotFound();

            var routeDTO = _mapper.Map<RouteDTO>(route);
            return Ok(routeDTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RouteDTO routeDTO)
        {
            if (routeDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            var route = _mapper.Map<Route>(routeDTO);
            _routeService.CreateRoute(route);
            return CreatedAtAction(nameof(Get), new { id = route.RouteId }, route);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] RouteDTO routeDto)
        {
            if (routeDto == null || id != routeDto.RouteId)
                return BadRequest("Invalid data.");

            var existingRoute = _routeService.GetRouteById(id);
            if (existingRoute == null)
                return NotFound();

            _mapper.Map(routeDto, existingRoute);
            _routeService.UpdateRoute(existingRoute);

            var updatedRouteDto = _mapper.Map<RouteDTO>(existingRoute);

            return Ok(updatedRouteDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingRoute = _routeService.GetRouteById(id);

            if (existingRoute == null)
            {
                return NotFound();
            }

            _routeService.DeleteRoute(id);
            return NoContent();
        }

        [HttpGet("count")]
        public int Count()
        {
            return _routeService.CountRoutes();
        }
    }
}
