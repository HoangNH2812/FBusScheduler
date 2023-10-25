﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Services;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class routationsController : ControllerBase
    {
        private readonly IRoutationService _routeTationService;
        private readonly IMapper _mapper;
        int PAGE_SIZE = 3;

        public routationsController(IRoutationService routeTationService, IMapper mapper)
        {
            _routeTationService = routeTationService;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string? filter = null, string? orderBy = null, int page = 1)
        {
            Expression<Func<Routation, bool>> filterExpression = null;
            Func<IQueryable<Routation>, IOrderedQueryable<Routation>> orderByFunc = null;

            if (!string.IsNullOrEmpty(filter))
            {

                filterExpression = routation =>
                    routation.StationId.ToString().Contains(filter) ||
                     routation.StationIndex.ToString().Contains(filter)||
                     routation.StationMode.ToString().Contains(filter);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "id":
                        orderByFunc = query => query.OrderBy(routation => routation.RouteId);
                        break;
                    case "id_desc":
                        orderByFunc = query => query.OrderByDescending(routation => routation.RouteId);
                        break;
                    // Thêm các trường hợp orderBy khác ở đây
                    default:
                        orderByFunc = query => query.OrderBy(routation => routation.RouteId); // Sử dụng một trường khác thích hợp
                        break;
                }
            }

            var routations = await _routeTationService.Get(filterExpression, orderByFunc);
            var pageroutations = PaginatedList<Routation>.Create(routations, page, PAGE_SIZE);
            return Ok(pageroutations);
        }

        //[Authorize]
        [HttpGet("routeid")]
        public async Task<IActionResult> GetById(int routeId)
        {
            var route = await _routeTationService.GetByID(routeId);
            return Ok(route);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int routeId, RoutationVM routationVM)
        {
            Routation routation = _mapper.Map<RoutationVM, Routation>(routationVM);
            routation.RouteId = routeId;
            await _routeTationService.AddAsync(routation);
            return Ok(routation);
        }

        //[Authorize]
        [HttpPut("routeid")]
        public async Task<IActionResult> Update(int routeId, [FromBody] RoutationVM routationVM)
        {
            var routation = _mapper.Map<RoutationVM, Routation>(routationVM);
            routation.RouteId = routeId;
            await _routeTationService.UpdateAsync(routation);
            return Ok(routation);
        }

        //[Authorize]
        [HttpDelete("routeid")]
        public async Task<IActionResult> Delete(int routeId)
        {
            var route = await _routeTationService.GetByID(routeId);
            if (route == null)
                return NotFound();

            await _routeTationService.DeleteAsync(routeId);
            return Ok();
        }
    }
}
