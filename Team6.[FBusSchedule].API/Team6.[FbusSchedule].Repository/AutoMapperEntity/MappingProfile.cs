using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team6._FbusSchedule_.Repository.DTO;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Repository.AutoMapperEntity
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<BusDTO, Bus>();
            CreateMap<Bus, BusDTO>();
        }
    }
}
