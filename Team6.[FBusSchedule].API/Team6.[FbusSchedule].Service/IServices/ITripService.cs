using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface ITripService
    {
        Task<List<Trip>> Get(Expression<Func<Trip, bool>> filter = null,
            Func<IQueryable<Trip>, IOrderedQueryable<Trip>> orderBy = null,
            params Expression<Func<Trip, object>>[] includeProperties);

        Task<Trip> GetByID(int id, params Expression<Func<Trip, object>>[] includeProperties);
        Task AddAsync(Trip entity);
        Task AddRangeAsync(List<Trip> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Trip entityToDelete);
        Task UpdateAsync(Trip entityToUpdate);
        void Dispose();
    }
}
