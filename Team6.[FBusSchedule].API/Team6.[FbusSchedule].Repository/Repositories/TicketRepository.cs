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
    public class TicketRepository : GenericRepository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(PostgresContext context) : base(context)
        {
        }

        public Task<int> CountByTripId(int tripId)
        {
            return  context.Tickets
            .Where(t => t.TripId == tripId)
            .CountAsync();
        }
    }
}
