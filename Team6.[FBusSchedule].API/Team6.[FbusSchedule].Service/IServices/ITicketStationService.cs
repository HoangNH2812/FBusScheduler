using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface ITicketStationService
    {
        Task<List<TicketStation>> Get(Expression<Func<TicketStation, bool>> filter = null,
            Func<IQueryable<TicketStation>, IOrderedQueryable<TicketStation>> orderBy = null,
            params Expression<Func<TicketStation, object>>[] includeProperties);

        Task<TicketStation> GetByID(int id, params Expression<Func<TicketStation, object>>[] includeProperties);
        Task AddAsync(TicketStation entity);
        Task AddRangeAsync(List<TicketStation> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(TicketStation entityToDelete);
        Task UpdateAsync(TicketStation entityToUpdate);
        void Dispose();
    }
}
