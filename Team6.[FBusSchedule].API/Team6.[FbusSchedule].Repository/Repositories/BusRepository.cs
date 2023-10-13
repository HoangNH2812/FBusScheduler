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
    public class BusRepository : GenericRepository<Bus, int>, IBusRepository
    {
        public BusRepository(PostgresContext context) : base(context)
        {
        }
    }
}
