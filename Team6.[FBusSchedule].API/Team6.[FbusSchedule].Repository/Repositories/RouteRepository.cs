using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;

namespace Team6._FbusSchedule_.Repository.Repository
{
    public class RouteRepository : GenericRepository<Route, int>, IRouteRepository
    {
        public RouteRepository(PostgresContext context) : base(context)
        {
        }
    }
}
