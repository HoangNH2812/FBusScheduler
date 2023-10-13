using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface IRoutationService
    {
        Task<List<Routation>> Get(Expression<Func<Routation, bool>> filter = null,
        Func<IQueryable<Routation>, IOrderedQueryable<Routation>> orderBy = null,
        params Expression<Func<Routation, object>>[] includeProperties);
        Task<Routation> GetByID(int id, params Expression<Func<Routation, object>>[] includeProperties);
        Task AddAsync(Routation entity);
        Task AddRangeAsync(List<Routation> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Routation entityToDelete);
        Task UpdateAsync(Routation entityToUpdate);
        void Dispose();
    }
}
