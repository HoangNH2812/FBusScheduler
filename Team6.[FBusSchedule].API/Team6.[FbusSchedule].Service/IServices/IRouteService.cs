using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface IRouteService
    {
        Task<List<Route>> Get(Expression<Func<Route, bool>> filter = null,
        Func<IQueryable<Route>, IOrderedQueryable<Route>> orderBy = null,
        params Expression<Func<Route, object>>[] includeProperties);
        Task<Route> GetByID(int id
            , params Expression<Func<Route, object>>[] includeProperties);
        Task AddAsync(Route entity);
        Task AddRangeAsync(List<Route> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Route entityToDelete);
        Task UpdateAsync(Route entityToUpdate);
        void Dispose();
    }
}
