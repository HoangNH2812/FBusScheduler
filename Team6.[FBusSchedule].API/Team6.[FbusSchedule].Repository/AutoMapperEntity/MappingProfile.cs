using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;

namespace Team6._FbusSchedule_.Repository.AutoMapperEntity
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<BusDTO, Bus>();
            CreateMap<Bus, BusDTO>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<DriverDTO, Driver>();
            CreateMap<Driver, DriverDTO>();

            CreateMap<RouteDTO, Route>();
            CreateMap<Route, RouteDTO>();

            CreateMap<StationDTO, Station>();
            CreateMap<Station, StationDTO>();

            CreateMap<Bus, BusVM>();
            CreateMap<BusVM, Bus>();

            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, Customer>();

            CreateMap<Driver, DriverVM>();
            CreateMap<DriverVM, Driver>();

            CreateMap<Route, RouteVM>();
            CreateMap<RouteVM, Route>();

            CreateMap<Station, StationVM>();
            CreateMap<StationVM, Station>();
        }
    }
}
