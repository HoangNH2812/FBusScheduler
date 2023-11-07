using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;
using Team6._FbusSchedule_.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Team6._FbusSchedule_.Repository.Repositories
{
    public class DetailTripRepository : GenericRepository<DetailTrip, int>, IDetailTripRepository
    {
        public DetailTripRepository(PostgresContext context) : base(context)
        {
        }

        public Task<DetailTrip> GetByTripAndStationId(int tripid, int stationid)
        {
            return context.DetailTrips
             .FirstOrDefaultAsync(dt => dt.TripID == tripid && dt.StationID == stationid);
        }
    }
}
