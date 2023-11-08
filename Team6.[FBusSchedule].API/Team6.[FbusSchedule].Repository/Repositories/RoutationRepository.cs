using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;

namespace Team6._FbusSchedule_.Repository.Repositories
{
    public class RoutationRepository : GenericRepository<Routation, int>, IRoutationRepository
    {
        public RoutationRepository(PostgresContext context) : base(context)
        {          
        }
        public Task<Routation> GetByRouteAndStationId(int tripid, int stationid)
        {
            return context.Routations
             .FirstOrDefaultAsync(dt => dt.RouteID == tripid && dt.StationID == stationid);
        }
    }
}
