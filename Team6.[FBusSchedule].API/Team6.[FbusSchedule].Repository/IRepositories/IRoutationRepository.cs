﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Repository.IRepositories
{
    public interface IRoutationRepository: IGenericRepository<Routation, int>
    {
        Task<Routation> GetByRouteAndStationId(int tripid, int stationid);
    }
}
