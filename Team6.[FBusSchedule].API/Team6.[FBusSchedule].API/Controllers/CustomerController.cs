﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public customersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        // GET: api/Bus
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var _list = await _customerService.Get();
            return Ok(_list);
        }


        // GET: api/Bus/5
        [HttpGet("{customerid}")]
        public async Task<IActionResult> ListByID(int CustomerId)
        {
            var _listbyid = await _customerService.GetByID(CustomerId);
            return Ok(_listbyid);
        }

        // POST: api/Bus
        [HttpPost]
        public async Task<IActionResult> Create(int CusID,CustomerVM cusVM)
        {
            Customer cus = new Customer();
            cus = _mapper.Map<CustomerVM, Customer>(cusVM);
            cus.CustomerId = CusID;
            await _customerService.AddAsync(cus);
            return Ok(cus);
        }


        [HttpPut("{customerid}")]
        public async Task<IActionResult> Update(int CustomerId, CustomerVM customerVM)
        {
            var cus = _mapper.Map<CustomerVM, Customer>(customerVM);
            cus.CustomerId = CustomerId;
            await _customerService.UpdateAsync(cus);
            return Ok(cus);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{customerid}")]
        public async Task<IActionResult> Delete(int CustomerId)
        {
            var customer = await _customerService.GetByID(CustomerId);
            if (customer == null)
                return NotFound();
            _customerService.DeleteAsync(CustomerId);
            return Ok();
        }
    }
}
