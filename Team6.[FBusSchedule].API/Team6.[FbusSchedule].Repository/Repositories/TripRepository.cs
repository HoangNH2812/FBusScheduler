using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;
using Team6._FbusSchedule_.Repository.Data;

namespace Team6._FbusSchedule_.Repository.Repositories
{
    public class TripRepository : GenericRepository<Trip, int>, ITripRepository
    {
        public TripRepository(PostgresContext context) : base(context)
        {
        }
    }
}
