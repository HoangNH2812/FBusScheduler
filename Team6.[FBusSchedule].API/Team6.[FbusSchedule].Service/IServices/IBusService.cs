using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface IBusService
    {
        Task<List<Bus>> Get(Expression<Func<Bus, bool>> filter = null,
        Func<IQueryable<Bus>, IOrderedQueryable<Bus>> orderBy = null,
        params Expression<Func<Bus, object>>[] includeProperties);
        Task<Bus> GetByID(int id
            , params Expression<Func<Bus, object>>[] includeProperties);
        Task AddAsync(Bus entity);
        Task AddRangeAsync(List<Bus> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Bus entityToDelete);
        Task UpdateAsync(Bus entityToUpdate);
        void Dispose();
    }
}
