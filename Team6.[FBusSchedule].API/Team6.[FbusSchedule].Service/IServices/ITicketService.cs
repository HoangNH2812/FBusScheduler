using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface ITicketService
    {
        Task<List<Ticket>> Get(Expression<Func<Ticket, bool>> filter = null,
            Func<IQueryable<Ticket>, IOrderedQueryable<Ticket>> orderBy = null,
            params Expression<Func<Ticket, object>>[] includeProperties);

        Task<Ticket> GetByID(int id, params Expression<Func<Ticket, object>>[] includeProperties);
        Task AddAsync(Ticket entity);
        Task AddRangeAsync(List<Ticket> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Ticket entityToDelete);
        Task UpdateAsync(Ticket entityToUpdate);
        void Dispose();
        Task<int> CountByTripId(int tripId);
    }
}
